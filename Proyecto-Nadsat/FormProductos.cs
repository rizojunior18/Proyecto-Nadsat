using DATA;
using Microsoft.VisualBasic;
using Models;
using Proyecto_Nadsat;
using System.Data;



namespace ProductoForm
{
    public partial class FormProductos : Form
    {
        FileDBProducts archivo = new FileDBProducts();

        public FormProductos()
        {
            InitializeComponent();
            this.ControlBotones("Inicio");
            this.txtRuta.Hide();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }





        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            DialogResult respuesta = this.openFileDialog1.ShowDialog();
            if (respuesta == DialogResult.Cancel) return;
            else
            {
                this.txtRuta.Text = this.openFileDialog1.FileName;
                LecturaDatos();
                CargaLista();
                this.ControlBotones("Cancelar");


            }

        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter(this.txtRuta.Text);
            writer.BaseStream.Seek(0, SeekOrigin.Begin);

            foreach (Producto p in archivo.PrintProduct())
            {
                string registro =

                (p.IdProducto + "," + p.NombreProducto + "," + p.Descripcion + "," + p.Categoria + "," + p.Marca + "," + p.Precio
                + "," + p.CantidadDisponible + ",");
                //(p.Id + "," + p.NombreProducto + "," + p.Descripcion + "," +
                //p.Cantidad + "," + p.Precio + "," + p.Estado + ",");

                writer.WriteLine(registro);
            }


            writer.Close();

            MessageBox.Show("Se guardó la lista en Archivo", "Información");
            this.Close();

        }
        public void CargaLista()
        {
            // Carga de List<Producto>   en el DataGridView por medio de DataTable
            // 
            this.dataProductos.Columns.Clear();
            //  this.dataProductos.Refresh();


            DataTable lista = new DataTable();
            lista.Columns.Add("Id Producto");
            lista.Columns.Add("Nombre de Producto");
            lista.Columns.Add("Descripcion");
            lista.Columns.Add("Categoria ");
            lista.Columns.Add("Marca");
            lista.Columns.Add("Cantidad Disponible");

            this.archivo.PrintProduct().ForEach(
                delegate (Producto p)
                {
                    lista.Rows.Add(new Object[]
                    {
                 p.IdProducto,
                 p.NombreProducto,
                 p.Descripcion,
                 p.Categoria,
                 p.Marca,
                 p.CantidadDisponible,
                    });
                }
                 );
            this.dataProductos.DataSource = lista;

        }
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                GuardarProducto();
                CargaLista();
                MessageBox.Show("Se guardo el registro en Lista", "Información");
                this.ControlBotones("Cancelar");
            }
            catch (Exception)
            {
                MessageBox.Show("Error detectado, por favor coloque datos antes de guardar el objeto");
            }
        }
        public void GuardarProducto()
        {

            //FileDB.writer.BaseStream.Seek(0, SeekOrigin.End);
            // string registro =
            //     (this.txtID.Text + "," + this.txtNombreProducto.Text + "," + this.txtDescripcion.Text + "," +
            //     this.txtCantidad.Text + "," + this.txtPrecio.Text + "," + "Habilitado");
            // FileDB.writer.WriteLine(registro);
            // FileDB.writer.Close();
            // MessageBox.Show("Se guardo el registro en Archivo", "Información");

            Producto p = new Producto();



            p.IdProducto = Convert.ToInt32(this.txtIDProducto.Text);
            p.NombreProducto = this.txtNombredeProducto.Text;
            p.Descripcion = this.txtDescripcion.Text;
            p.Categoria = this.txtCategoria.Text;
            p.Marca = this.txtMarca.Text;
            p.Precio = Convert.ToInt32(this.txtPrecio.Text);
            p.CantidadDisponible = Convert.ToInt32(this.txtCantidadDisponible.Text);


            archivo.AddProduct(p);

            this.CargaLista();

            MessageBox.Show("Producto guardado exitosamente!");

            this.ControlBotones("Cancelar");




        }

        public void LecturaDatos()
        {
            // Lectura de Datos del archivo de Datos y carga en List<Producto>


            if (this.txtRuta.Text == "")
            {
                MessageBox.Show("Seleccione el boton Buscar para establecer " +
                    "ruta del archivo", "Validación");
            }
            else
            {
                StreamReader reader = new StreamReader(this.txtRuta.Text);
                string registro = reader.ReadLine();
                while (registro != null)
                {
                    Producto p = new Producto();
                    int posFinal = registro.IndexOf(',');
                    p.IdProducto = Convert.ToInt32(registro.Substring(0, posFinal));
                    /****************************************************/
                    registro = registro.Substring(posFinal + 1);
                    posFinal = registro.IndexOf(',');
                    p.NombreProducto = registro.Substring(0, posFinal);
                    /****************************************************/
                    registro = registro.Substring(posFinal + 1);
                    posFinal = registro.IndexOf(',');
                    p.Descripcion = registro.Substring(0, posFinal);
                    /****************************************************/
                    registro = registro.Substring(posFinal + 1);
                    posFinal = registro.IndexOf(',');
                    p.Categoria = registro.Substring(0, posFinal);
                    /****************************************************/
                    registro = registro.Substring(posFinal + 1);
                    posFinal = registro.IndexOf(',');
                    p.Marca = registro.Substring(0, posFinal);
                    /****************************************************/
                    registro = registro.Substring(posFinal + 1);
                    posFinal = registro.IndexOf(',');
                    p.Precio = Convert.ToInt32(registro.Substring(0, posFinal));
                    /****************************************************/
                    registro = registro.Substring(posFinal + 1);
                    posFinal = registro.IndexOf(',');
                    p.CantidadDisponible = Convert.ToInt32(registro.Substring(0, posFinal));
                    /****************************************************/



                    archivo.AddProduct(p);


                    registro = reader.ReadLine();

                }
                reader.Close();


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.ControlBotones("Buscar");


        }


        private void dataProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtIDProducto.Text = Convert.ToString(this.dataProductos.CurrentRow.Cells["Id Producto"].Value);
            this.txtNombredeProducto.Text = Convert.ToString(this.dataProductos.CurrentRow.Cells["Nombre Producto"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataProductos.CurrentRow.Cells["Descripción"].Value);
            this.txtCategoria.Text = Convert.ToString(this.dataProductos.CurrentRow.Cells["Categoria"].Value);
            this.txtMarca.Text = Convert.ToString(this.dataProductos.CurrentRow.Cells["Marca"].Value);
            this.txtPrecio.Text = Convert.ToString(this.dataProductos.CurrentRow.Cells["Precio"].Value);
            this.txtCantidadDisponible.Text = Convert.ToString(this.dataProductos.CurrentRow.Cells["Cantidad Disponible"].Value);
            //this.txtEstado.Text = Convert.ToString(this.dataProductos.CurrentRow.Cells["Estado"].Value);

            this.ControlBotones("Modificar");
        }

        private void btnModicar_Click_1(object sender, EventArgs e)
        {
            int idProducto = Convert.ToInt32(Interaction.InputBox("Ingrese el ID"));

            //this.archivo.UpdateProducto(
            //    idProducto,
            //    this.txtNombredeProducto.Text,
            //    this.txtDescripcion.Text,
            //    this.txtCategoria.Text,
            //    this.txtMarca.Text,
            //    this.txtPrecio.Text,
            //    this.txtCantidadDisponible.Text
            //    //
            //);

            MessageBox.Show("Registro Actualizado", "Información");
            CargaLista();
            this.ControlBotones("Cancelar");
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            int id;
            id = archivo.PrintProduct().Count;
            this.txtIDProducto.Text = Convert.ToString(id);
            this.ControlBotones("Nuevo");

        }
        public void LimpiarTextbox()
        {
            this.txtIDProducto.Text = String.Empty;
            this.txtIDProducto.Text = String.Empty;
            this.txtNombredeProducto.Text = String.Empty;
            this.txtDescripcion.Text = String.Empty;
            this.txtCategoria.Text = String.Empty;
            this.txtMarca.Text = String.Empty;
            this.txtPrecio.Text = String.Empty;
            this.txtCantidadDisponible.Text = String.Empty;

            // this.txtEstado.Text = String.Empty;
            this.dataProductos.ClearSelection();
        }

        public void HabilitarTextbox(bool dato)
        {
            this.txtIDProducto.Enabled = dato;
            this.txtNombredeProducto.Enabled = dato;
            this.txtDescripcion.Enabled = dato;
            this.txtCategoria.Enabled = dato;
            this.txtMarca.Enabled = dato;
            this.txtPrecio.Enabled = dato;
            this.txtCantidadDisponible.Enabled = dato;

            // this.txtEstado.Text = String.Empty;

        }

        public void ControlBotones(string dato)
        {
            if (dato == "Cancelar")
            {

                this.HabilitarTextbox(false);
                this.LimpiarTextbox();
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnModicar.Enabled = true;
                this.btnCancelar.Enabled = false;
                this.btnBuscar.Enabled = false;

            }
            else
            if (dato == "Nuevo")
            {

                this.HabilitarTextbox(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnModicar.Enabled = false;
                this.btnCancelar.Enabled = true;

            }

            else
            if (dato == "Modificar")
            {

                this.HabilitarTextbox(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = false;
                this.btnModicar.Enabled = true;
                this.btnCancelar.Enabled = true;

            }
            if (dato == "Estado")
            {

                this.HabilitarTextbox(false);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = false;
                this.btnModicar.Enabled = false;
                this.btnCancelar.Enabled = true;

            }
            if (dato == "Buscar")
            {

                this.HabilitarTextbox(false);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = false;

                this.btnModicar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnImprimir.Enabled = false;
                this.txtIDProducto.Enabled = false;


            }
            if (dato == "Inicio")
            {
                this.HabilitarTextbox(false);
                this.btnBuscar.Enabled = false;
                this.btnImprimir.Enabled = false;
                this.btnFiltrar.Enabled = false;
                this.btnGuardar.Enabled = false;
                this.btnModicar.Enabled = false;
                this.btnNuevo.Enabled = true;
                this.btnCancelar.Enabled = true;

            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.ControlBotones("Cancelar");
        }

        private void dataProductos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.ControlBotones("Estado");
        }


        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string id = Interaction.InputBox("Ingrese el Id de un producto");

            foreach (Producto c in archivo.PrintProduct())
            {
                if (c.IdProducto.Equals(id))
                {
                    this.dataProductos.Columns.Clear();

                    DataTable lista = new DataTable();

                    lista.Columns.Add("ID");
                    lista.Columns.Add("No. Cedula");
                    lista.Columns.Add("1er Nombre");
                    lista.Columns.Add("2do Nombre");
                    lista.Columns.Add("1er Apellido");
                    lista.Columns.Add("2do Apellido");
                    lista.Columns.Add("Correo");
                    lista.Columns.Add("Departamento");
                    lista.Columns.Add("Direccion");
                    lista.Columns.Add("Telefono");

                    lista.Rows.Add(new Object[]
                    {
                        c.IdProducto,
                        c.NombreProducto,
                        c.Descripcion,
                        c.Categoria,
                        c.Marca,
                        c.Precio,
                        c.CantidadDisponible
                    });

                    this.dataProductos.DataSource = lista;
                }
            }

        }

        private void btnSalvarArchivo_Click(object sender, EventArgs e)
        {

            imprimirArchivo();


        }

        public void imprimirArchivo()
        {
            string guardar = Interaction.InputBox("Ruta", "Ingrese la ruta", "ejemplo = C:\\Users\\Usuario\\Escritorio");
            //var currenPath = Directory.GetCurrentDirectory(); 
            string ruta = guardar + Path.DirectorySeparatorChar + "Archivo4.Json";
            var fileStream = new FileStream(ruta, FileMode.Create);

            StreamWriter writer = new StreamWriter(fileStream);

            foreach (Producto producto in archivo.PrintProduct())
            {
                writer.WriteLine(producto.IdProducto);
                writer.WriteLine(producto.NombreProducto);
                writer.WriteLine(producto.Descripcion);
                writer.WriteLine(producto.Categoria);
                writer.WriteLine(producto.Marca);
                writer.WriteLine(producto.Precio);
                writer.WriteLine(producto.CantidadDisponible);


            }

            writer.Close();
        }

       

        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //principal.Show();
            Principal mn = new Principal();
            this.Hide();
            mn.Show();

        }
    }
}
    