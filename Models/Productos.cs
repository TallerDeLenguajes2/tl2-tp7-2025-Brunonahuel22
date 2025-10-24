namespace Tp7.Models
{
    public class Productos 
    {
        int idProducto { get; set; }
        string? descripcion { get; set; }
        int precio { get; set; }

        public Productos()
        {}
        public Productos(int id , string desc,int pre)
        {
            idProducto = id;
            descripcion = desc;
            precio = pre;
        }

        
    }
    
}