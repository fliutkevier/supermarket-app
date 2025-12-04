using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Services
{
    public class FiscalServiceAfipSDK : IFiscalService
    {
        private const string BaseUrl = "https://app.afipsdk.com/api/v1/afip";
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;

        public FiscalServiceAfipSDK(IConfiguration config)
        {
            _config = config;
            _httpClient = new HttpClient();
        }

        private async Task<(string Token, string Sign)> ObtenerAutorizacionAsync()
        {
            string basePath = AppContext.BaseDirectory;

            // 2. Apunta a la carpeta "Services" que está ahí dentro
            string crtPath = Path.Combine(basePath, "Services", "SistemaFacturacion_4b4633f62dd42800.crt");
            string keyPath = Path.Combine(basePath, "Services", "prod-private.key");

            // 3. Verificación de seguridad (ahora debería pasar)
            if (!File.Exists(crtPath))
                throw new FileNotFoundException($"No se encontró el certificado. Ruta intentada: {crtPath}");

            if (!File.Exists(keyPath))
                throw new FileNotFoundException($"No se encontró la clave privada. Ruta intentada: {keyPath}");

            // 4. Lectura asíncrona
            var cert = await File.ReadAllTextAsync(crtPath);
            var key = await File.ReadAllTextAsync(keyPath);
            //var cert = File.ReadAllText("C:/code/VerticeApp/VerticeSolution/Infrastructure/Services/SistemaFacturacion_4b4633f62dd42800.crt");
            //var key = File.ReadAllText("C:/code/VerticeApp/VerticeSolution/Infrastructure/Services/prod-private.key");
            //var afip = new Afip(new { CUIT = 20111111112, cert = cert, key = key, access_token = "TU_ACCESS_TOKEN" });
            //string cert = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SistemaFacturacion_4b4633f62dd42800.crt");
            //string key = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "prod-private.key");
            string authUrl = $"{BaseUrl}/auth";

            // Leemos configuración del appsettings.json
            string env = _config["AfipSdk:Environment"];
            string cuit = _config["AfipSdk:Cuit"];
            string libraryToken = _config["AfipSdk:AccessToken"];

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {libraryToken}");

            var authData = new
            {
                environment = env,
                tax_id = cuit,
                wsid = "wsfe",
                cert,
                key
            };

            var jsonContent = JsonConvert.SerializeObject(authData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(authUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error Auth AfipSDK: {response.StatusCode} - {error}");
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            dynamic auth = JsonConvert.DeserializeObject(responseBody);

            return (auth.token, auth.sign);
        }

        private async Task<int> ObtenerProximoNumeroComprobanteAsync(string token, string sign, int ptoVta, int cbteTipo)
        //private async Task<int> ObtenerProximoNumeroComprobanteAsync(string token, string sign)
        {
            string url = $"{BaseUrl}/requests";
            string env = _config["AfipSdk:Environment"];
            string cuit = _config["AfipSdk:Cuit"];

            var requestData = new
            {
                environment = env,
                method = "FECompUltimoAutorizado",
                wsid = "wsfe",
                @params = new
                {
                    Auth = new { Token = token, Sign = sign, Cuit = cuit },
                    PtoVta = ptoVta,
                    CbteTipo = cbteTipo
                }
            };

            var jsonContent = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                // Si falla, devolvemos 0 para que el próximo sea 1 (útil en testing)
                return 0;
            }

            var responseString = await response.Content.ReadAsStringAsync();
            try
            {
                JObject jsonResponse = JObject.Parse(responseString);
                int ultimo = (int)jsonResponse["FECompUltimoAutorizadoResult"]["CbteNro"];
                return ultimo + 1;
            }
            catch
            {
                return 1;
            }
        }

        public async Task<FiscalDocument> GenerateInvoiceAsync(Sale sale)
        {
            // 1. Auth
            var (token, sign) = await ObtenerAutorizacionAsync();

            // 2. Configuración
            int ptoVta = int.Parse(_config["AfipSdk:PuntoVenta"]);
            string cuitEmisor = _config["AfipSdk:Cuit"];
            string env = _config["AfipSdk:Environment"];

            // Lógica de Tipos (A o B)
            int cbteTipo = 6;
            int docTipo = 99;
            long docNro = 0;

            // 3. Próximo Número
            int proximoNumero = await ObtenerProximoNumeroComprobanteAsync(token, sign, ptoVta, cbteTipo);

            // 4. Cálculos de Importes (Dinámicos según la Venta)
            decimal total = Math.Round(sale.Total, 2);
            decimal neto = Math.Round(total / 1.21m, 2);
            decimal iva = Math.Round(total - neto, 2);
            if (neto + iva != total) iva = total - neto; // Ajuste centavos

            // 5. Armado del JSON (Con la estructura que funcionó)
            var invoiceData = new
            {
                environment = env,
                method = "FECAESolicitar",
                wsid = "wsfe",
                @params = new
                {
                    Auth = new { Token = token, Sign = sign, Cuit = cuitEmisor },
                    FeCAEReq = new
                    {
                        FeCabReq = new
                        {
                            CantReg = 1,
                            PtoVta = ptoVta,
                            CbteTipo = cbteTipo
                        },
                        FeDetReq = new
                        {
                            FECAEDetRequest = new // Objeto único, no array, según tu prueba exitosa
                            {
                                Concepto = 1,
                                DocTipo = docTipo,
                                DocNro = docNro,
                                CbteDesde = proximoNumero,
                                CbteHasta = proximoNumero,
                                CbteFch = sale.DateAndTime.ToString("yyyyMMdd"),
                                ImpTotal = total,
                                ImpTotConc = 0,
                                ImpNeto = neto,
                                ImpOpEx = 0,
                                ImpTrib = 0,
                                ImpIVA = iva,
                                MonId = "PES",
                                MonCotiz = 1,
                                CondicionIVAReceptorId = (cbteTipo == 1) ? 1 : 5, // 1=Resp Insc, 5=Cons Final
                                Iva = new
                                {
                                    AlicIva = new[]
                                    {
                                        new { Id = 5, BaseImp = neto, Importe = iva } // 21%
                                    }
                                }
                            }
                        }
                    }
                }
            };

            // 6. Enviar
            string url = $"{BaseUrl}/requests";
            var jsonContent = JsonConvert.SerializeObject(invoiceData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error Facturación AFIP: {responseString}");
            }

            JObject result = JObject.Parse(responseString);
            var fecaesolicitarResult = result["FECAESolicitarResult"];

            if (fecaesolicitarResult == null) throw new Exception($"Respuesta vacía de AFIP: {responseString}");

            // 1. Resultado Cabecera
            string resultadoCabecera = (string)fecaesolicitarResult["Resultado"];

            // 2. Navegación Robusta para encontrar el Detalle
            // AFIP a veces devuelve: FeDetResp -> [ { ... } ]
            // Y a veces: FeDetResp -> FECAEDetResponse -> [ { ... } ]

            JToken detalleToken = fecaesolicitarResult["FeDetResp"];

            // Si es un array (caso simple), tomamos el primero
            if (detalleToken is JArray arr1 && arr1.Count > 0)
            {
                detalleToken = arr1[0];
            }

            // Ahora detalleToken es un Objeto. Verificamos si tiene el envoltorio "FECAEDetResponse" adentro.
            if (detalleToken != null && detalleToken["FECAEDetResponse"] != null)
            {
                var innerToken = detalleToken["FECAEDetResponse"];
                // Si lo de adentro es un array, tomamos el primero
                if (innerToken is JArray arr2 && arr2.Count > 0)
                {
                    detalleToken = arr2[0];
                }
                else
                {
                    detalleToken = innerToken;
                }
            }

            // Ahora sí, detalleToken debería ser el objeto final con el CAE
            string cae = (string)detalleToken?["CAE"];
            string vto = (string)detalleToken?["CAEFchVto"];

            // 3. Validación Final
            if (string.IsNullOrEmpty(cae) || resultadoCabecera == "R")
            {
                string errorMsg = "AFIP Rechazó.";

                // Buscar errores en Cabecera
                var errors = fecaesolicitarResult["Errors"]?["Err"];
                if (errors != null)
                {
                    if (errors is JArray errArr) errorMsg += " " + (string)errArr[0]["Msg"];
                    else errorMsg += " " + (string)errors["Msg"];
                }

                // Buscar observaciones en Detalle
                if (detalleToken != null)
                {
                    var obs = detalleToken["Observaciones"]?["Obs"];
                    if (obs != null)
                    {
                        if (obs is JArray obsArr) errorMsg += " | Obs: " + (string)obsArr[0]["Msg"];
                        else errorMsg += " | Obs: " + (string)obs["Msg"];
                    }
                }

                throw new Exception(errorMsg);
            }

            return new FiscalDocument
            {
                PointOfSale = ptoVta,
                InvoiceType = cbteTipo,
                InvoiceNumber = proximoNumero,
                CAE = cae,
                CAEExpirationDate = DateTime.ParseExact(vto, "yyyyMMdd", null),
                CustomerDocType = docTipo.ToString(),
                CustomerDocNumber = docNro.ToString()
            };
        }
    }
}
