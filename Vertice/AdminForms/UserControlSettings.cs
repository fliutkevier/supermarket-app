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

namespace WinForms.AdminForms
{
    public partial class UserControlSettings : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        public UserControlSettings(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void btnRecicle_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<FormRecoverElements>();
            form.ShowDialog();
        }
    }
}
