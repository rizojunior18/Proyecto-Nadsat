using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Nadsat
{
    public partial class Login : Form
    {
        LoginMain loginMain = new LoginMain();

        public Login()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginMain.Show();
        }
    }
}
