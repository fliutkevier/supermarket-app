using Application.Products.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms.PopUps;

namespace WinForms
{
    public partial class UserControlProducts : UserControl
    {
        private readonly IProductService _productService;
        private readonly IServiceProvider _serviceProvider;
        public UserControlProducts(IProductService productService,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _productService = productService;
            _serviceProvider = serviceProvider;
        }

        private void UserControlProducts_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var editor = _serviceProvider.GetRequiredService<FormProductEditor>();
            var result = editor.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadGrid();
            }
        }

        private async void LoadGrid()
        {
            try
            {
                var products = await _productService.GetAllForGridAsync();

                dgvProducts.DataSource = products.ToList();

                ConfigGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigGrid()
        {
            if (dgvProducts.Columns.Count == 0) return;

            dgvProducts.Columns["Code"].HeaderText = "Código";

            dgvProducts.Columns["Name"].HeaderText = "Nombre";

            dgvProducts.Columns["SalePrice"].HeaderText = "Precio Venta";
            dgvProducts.Columns["SalePrice"].DefaultCellStyle.Format = "C2"; // Formato Moneda ($ 1,200.00)
            dgvProducts.Columns["SalePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            dgvProducts.Columns["CostPrice"].HeaderText = "Costo";
            dgvProducts.Columns["CostPrice"].DefaultCellStyle.Format = "C2";
            dgvProducts.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            dgvProducts.Columns["Stock"].HeaderText = "Stock Actual";
            dgvProducts.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dgvProducts.Columns["LastStockUpdate"].HeaderText = "Últ. Actualización";
            dgvProducts.Columns["LastStockUpdate"].DefaultCellStyle.Format = "g"; // Formato fecha corta + hora

        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;

            string code = dgvProducts.CurrentRow.Cells["Code"].Value.ToString();

            if (code == null) return;

            var editor = _serviceProvider.GetRequiredService<FormProductEditor>();
            editor.LoadForEdit(code);

            var result = editor.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadGrid();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string code = dgvProducts.CurrentRow.Cells["Code"].Value.ToString();
            string name = dgvProducts.CurrentRow.Cells["Name"].Value.ToString();

            var confirmResult = MessageBox.Show(
                $"¿Está seguro que desea eliminar el producto '{name}'?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    await _productService.SoftDeleteProductAsync(code);

                    MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
