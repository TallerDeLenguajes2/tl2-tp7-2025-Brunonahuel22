namespace Tp7.Models
{
    public class Presupuestos
    {
        int idPresupuesto { get; set; }
        string? nombreDestinatario { get; set; }
        string? FechaCreacion { get; set; }
        List<PresupuestosDetalle>? detalle;

        public Presupuestos()
        {    
        }
        public Presupuestos(int id, string destinatario, string fecha, List<PresupuestosDetalle> lista)
        {
            idPresupuesto = id;
            nombreDestinatario = destinatario;
            FechaCreacion = fecha;
            detalle = lista;
        }
        

    }
}