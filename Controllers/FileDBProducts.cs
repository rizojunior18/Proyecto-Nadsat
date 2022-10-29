using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DATA
{
    public  class FileDBProducts
    {
       
           
       

        List<Producto> producto = new List<Producto>();


        public void AddProduct(Producto producto)
        {
            this.producto.Add(producto);

        }
        public List<Producto> PrintProduct()
        {
            return this.producto;
        }

        public void UpdateProducto(int index, int idProducto, string nombreDeProducto, string descripcion, string categoria,
            string marca, int precio, int cantidadDisponible)
        {


            //this.producto[index].Idcliente = idCliente;


            this.producto[index].IdProducto = idProducto;
            this.producto[index].NombreProducto = nombreDeProducto;
            this.producto[index].Descripcion = descripcion;
            this.producto[index].Categoria = categoria;
            this.producto[index].Marca = marca;
            this.producto[index].Precio = precio;
            this.producto[index].CantidadDisponible = cantidadDisponible;

        }
          
        //public void UpdateEstado(int index)
        //{
        //    if (this.producto[index].Estado == "Habilitado")
        //    {
        //        this.producto[index].Estado = "Deshabilitado";
        //    }
        //    else
        //        this.producto[index].Estado = "Habilitado";
        //}

    }
}
