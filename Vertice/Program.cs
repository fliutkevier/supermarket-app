using Application.Employees;
using Application.Employees.Interfaces;
using Application.PaymentMethods;
using Application.PaymentMethods.Interfaces;
using Application.Products;
using Application.Products.Interfaces;
using Application.Providers;
using Application.Providers.Interfaces;
using Application.Sales;
using Application.Sales.Interfaces;
using Application.Sessions;
using Application.Sessions.Interfaces;
using Application.Users;
using Application.Users.Interfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinForms;
using WinForms.AdminForms;
using WinForms.PopUps;

namespace Vertice
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var host = CreateHostBuilder().Build();

            ApplyMigrations(host.Services);

            SeedDatabase(host.Services);

            var form = host.Services.GetRequiredService<FormLogin>();

            System.Windows.Forms.Application.Run(form);
        }

        private static void SeedDatabase(IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                try
                {
                    // Verificamos si existe el producto "Comodín"
                    if (!context.Products.Any(p => p.Code == "VARIOS"))
                    {
                        var productoVarios = new Product
                        {
                            Code = "VARIOS",
                            Name = "Varios / Fiambrería",
                            SalePrice = 0,
                            CostPrice = 0,
                            Stock = 999999,
                            IsActive = true,
                            IsOpenPrice = true,
                            LastStockUpdate = DateTime.Now
                        };

                        context.Products.Add(productoVarios);
                        context.SaveChanges();
                    }

                    // Usuario Admin por defecto si no existe ninguno
                    if (!context.Users.Any(u => u.Username == "lizbernal"))
                    {
                        var user = new User
                        {
                            Username = "lizbernal",
                            Password = "4231",
                            Role = 'A',
                            IsActive = true
                        };

                        context.Users.Add(user);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al sembrar datos iniciales: " + ex.Message);
                }
            }
        }

        private static void ApplyMigrations(IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                try
                {
                    dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error fatal: No se pudo conectar o aplicar las migraciones a la base de datos.\n" +
                        "La aplicación se cerrará.\n\n" +
                        "Error: " + ex.Message,
                        "Error Crítico de Base de Datos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    Environment.Exit(1);
                }
            }
        }

        static IHostBuilder CreateHostBuilder() => 
            Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                string connectionString;
                
                //DEV
                //connectionString = context.Configuration.GetConnectionString("DefaultConnection")!;

                
                //PROD
                //Definimos la ruta en ProgramData (para que los datos sobrevivan si desinstalas el exe)
                string appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "VerticeApp");

                if (!Directory.Exists(appDataFolder))
                {
                    Directory.CreateDirectory(appDataFolder);
                }

                string dbFilePath = Path.Combine(appDataFolder, "VerticeDB.mdf");

                //El "AttachDbFileName" es lo que hace que use el archivo en ProgramData.
                connectionString = $"Server=.\\SQLEXPRESS;Database=VerticeDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;AttachDbFileName={dbFilePath}";
                
                //========================

                //DEVELOPMENT
                //var connectionString = context.Configuration.GetConnectionString("DefaultConnection")!;

                // Inyectam DbContext
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(connectionString));

                //Dependency Injection UI
                services.AddTransient<FormLogin>();
                services.AddTransient<FormAdminDashboard>();
                services.AddTransient<UserControlNewSales>();
                services.AddTransient<UserControlEmployees>();
                services.AddTransient<UserControlHistory>();
                services.AddTransient<UserControlLogs>();
                services.AddTransient<UserControlProducts>();
                services.AddTransient<UserControlProviders>();
                services.AddTransient<UserControlProvidersHistory>();
                services.AddTransient<UserControlPaymentMethods>();
                services.AddTransient<UserControlUsers>();

                services.AddTransient<FormEmployeeEditor>();
                services.AddTransient<FormPaymentMethodEditor>();
                services.AddTransient<FormProductEditor>();
                services.AddTransient<FormProviderEditor>();
                services.AddTransient<FormUserEditor>();
                services.AddTransient<FormSaleDetail>();

                //DI Data
                services.AddScoped<IAuditLogRepository, AuditLogRepository>();
                services.AddScoped<IEmployeeRepository, EmployeeRepository>();
                services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
                services.AddScoped<IProductRepository, ProductRepository>();
                services.AddScoped<IProviderMovementRepository, ProviderMovementRepository>();
                services.AddScoped<IProviderRepository, ProviderRepository>();
                services.AddScoped<ISaleDetailRepository, SaleDetailRepository>();
                services.AddScoped<ISaleRepository, SaleRepository>();
                services.AddScoped<ISessionRepository, SessionRepository>();
                services.AddScoped<IUserRepository, UserRepository>();
                services.AddScoped<IUnitOfWork, UnitOfWork>();
                services.AddSingleton<IUserSessionService, UserSessionService>();

                //DI App
                services.AddScoped<IAuthService, AuthService>();
                services.AddScoped<IProductService, ProductService>();
                services.AddScoped<IPaymentMethodService, PaymentMethodService>();
                services.AddScoped<IProviderService, ProviderService>();
                services.AddScoped<IEmployeeService, EmployeeService>();
                services.AddScoped<ISessionService, SessionService>();
                services.AddScoped<ISaleService, SaleService>();
                services.AddScoped<IFiscalService, FiscalServiceAfipSDK>();
                services.AddScoped<IRepository<FiscalDocument>, SqlRepository<FiscalDocument>>();
                services.AddScoped<IUserService, UserService>();
            });
    }
}