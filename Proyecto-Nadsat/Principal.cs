using ProductoForm;
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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible= true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //frmProductos.Show();
            FormProductos FPs = new FormProductos();
            FPs.TopLevel = false;
            this.pnlContenedor.Controls.Add(FPs);
            FPs.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormProductos fps = new FormProductos();
            fps.TopLevel = false;
            pnlContenedor.Controls.Add(fps);
            fps.Show();
        }
    }
}
