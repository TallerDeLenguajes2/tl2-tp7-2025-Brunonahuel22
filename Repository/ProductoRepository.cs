using Tp7.Models;
using Microsoft.Data.Sqlite;
using SQLitePCL;
namespace Tp7.Repository;



public class ProductoRepository
{
    string cadenaConexion = "Data Source=tienda.db";
    public Productos crearProducto(Productos producto)
    {

        using SqliteConnection connection = new SqliteConnection(cadenaConexion);

        connection.Open();

        string sql = "INSERT INTO Productos (descripcion, precio) VALUES (@descripcion, @precio)";
        using SqliteCommand comando = new SqliteCommand(sql, connection);

        comando.Parameters.Add(new SqliteParameter("@descripcion", producto.descripcion));
        comando.Parameters.Add(new SqliteParameter("@precio", producto.precio));


        comando.ExecuteNonQuery();

        

        return producto;

    }

    //Listar todos los Productos registrados. (devuelve un List de Producto)
    public List<Productos> listarProductos()
    {
        var lista = new List<Productos>();
        using var connection = new SqliteConnection(cadenaConexion);
         connection.Open();
        string sql = "SELECT * FROM Productos";

        using SqliteCommand comando = new SqliteCommand(sql, connection);

        using var lectura = comando.ExecuteReader();

        while (lectura.Read())
        {
            var p = new Productos
            {
                idProducto = Convert.ToInt32(lectura["idProducto"]),
                descripcion = lectura["descripcion"].ToString(),
                precio = Convert.ToInt32(lectura["precio"])

            };

            lista.Add(p);
        }

        return lista;
    }



}
