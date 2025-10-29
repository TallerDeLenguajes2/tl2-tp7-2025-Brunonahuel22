namespace Tp7.Models
{
    public class Presupuestos
    {
       private const decimal IVA = 0.21m;
        int idPresupuesto { get; set; }
        string? nombreDestinatario { get; set; }
        DateTime FechaCreacion { get; set; }
        List<PresupuestosDetalle> Detalle = new List<PresupuestosDetalle>();

        public Presupuestos()
        {
        }
        public Presupuestos(int id, string destinatario, DateTime fecha, List<PresupuestosDetalle> lista)
        {
            idPresupuesto = id;
            nombreDestinatario = destinatario;
            FechaCreacion = fecha;
            Detalle = lista;
        }

        public decimal MontoPresupuesto() 
        {
           
            decimal totalMonto = 0m; 

           
            foreach (var itemDetalle in Detalle)
            {
          
                totalMonto += itemDetalle.Subtotal(); 
            }

            return totalMonto;
        }

        
        public decimal MontoPresupuestoConIva() 
        {
           
            decimal montoSinIva = MontoPresupuesto(); 

           
            return montoSinIva * (1 + IVA);
        }

    
        public int CantidadProductos()
        {
            int totalCantidad = 0;
            foreach (var itemDetalle in Detalle)
            {
             
                totalCantidad += itemDetalle.cantidad; 
            }
            return totalCantidad;
        }


    


    }
}