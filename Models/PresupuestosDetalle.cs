namespace Tp7.Models
{
    public class PresupuestosDetalle
    {
        Productos? producto { get; set; }
        int cantidad { get; set; }

        public PresupuestosDetalle(){}
        public PresupuestosDetalle(Productos produ,int cant)
        {
            producto = produ;
            cantidad = cant;
        }
    }
}