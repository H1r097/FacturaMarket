using ProyectoFacturaMarket.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacturaMarket.Controlador
{
   public class ProductoDB
    {
        private readonly Conexion conexion = new Conexion();

        //Listar todos los productos 
        public List<Producto> ListarProductos()
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                string query = @"SELECT p.IDProducto, p.NombreProducto, p.IDCategoria, 
                                        c.NombreCategoria, p.PrecioCosto, p.PrecioVenta, 
                                        p.StockActual, p.StockMinimo, p.AplicaIva, p.Estado
                                 FROM Producto p
                                 INNER JOIN Categoria c ON p.IDCategoria = c.IDCategoria
                                 WHERE p.Estado = 1
                                 ORDER BY p.NombreProducto ASC";

                SqlCommand cmd = new SqlCommand(query, cn);

                try
                {
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Producto p = new Producto
                            {
                                IDProducto = Convert.ToInt32(dr["IDProducto"]),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                IDCategoria = Convert.ToInt32(dr["IDCategoria"]),
                                PrecioCosto = Convert.ToDecimal(dr["PrecioCosto"]),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                StockActual = Convert.ToDecimal(dr["StockActual"]),
                                StockMinimo = Convert.ToDecimal(dr["StockMinimo"]),
                                AplicaIva = Convert.ToBoolean(dr["AplicaIva"]),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                Categoria = new Categoria
                                {
                                    IDCategoria = Convert.ToInt32(dr["IDCategoria"]),
                                    NombreCategoria = dr["NombreCategoria"].ToString(),
                                    Estado = true
                                }
                            };

                            lista.Add(p);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar los productos: " + ex.Message);
                }
            }

            return lista;
        }

        // Insertar nuevo producto
        public bool InsertarProducto(Producto p)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                string query = @"INSERT INTO Producto (NombreProducto, IDCategoria, PrecioCosto, PrecioVenta, StockActual, StockMinimo, AplicaIva, Estado)
                                 VALUES (@Nombre, @IDCategoria, @PrecioCosto, @PrecioVenta, @StockActual, @StockMinimo, @AplicaIva, @Estado)";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Nombre", p.NombreProducto.Trim());
                cmd.Parameters.AddWithValue("@IDCategoria", p.IDCategoria);
                cmd.Parameters.AddWithValue("@PrecioCosto", p.PrecioCosto);
                cmd.Parameters.AddWithValue("@PrecioVenta", p.PrecioVenta);
                cmd.Parameters.AddWithValue("@StockActual", p.StockActual);
                cmd.Parameters.AddWithValue("@StockMinimo", p.StockMinimo);
                cmd.Parameters.AddWithValue("@AplicaIva", p.AplicaIva ? 1 : 0);
                cmd.Parameters.AddWithValue("@Estado", p.Estado ? 1 : 0);

                try
                {
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el producto: " + ex.Message);
                }
            }
        }

        // Modificar producto existente
        public bool ModificarProducto(Producto p)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                string query = @"UPDATE Producto 
                                 SET NombreProducto = @Nombre,
                                     IDCategoria = @IDCategoria,
                                     PrecioCosto = @PrecioCosto,
                                     PrecioVenta = @PrecioVenta,
                                     StockActual = @StockActual,
                                     StockMinimo = @StockMinimo,
                                     AplicaIva = @AplicaIva,
                                     Estado = @Estado
                                 WHERE IDProducto = @IDProducto";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IDProducto", p.IDProducto);
                cmd.Parameters.AddWithValue("@Nombre", p.NombreProducto.Trim());
                cmd.Parameters.AddWithValue("@IDCategoria", p.IDCategoria);
                cmd.Parameters.AddWithValue("@PrecioCosto", p.PrecioCosto);
                cmd.Parameters.AddWithValue("@PrecioVenta", p.PrecioVenta);
                cmd.Parameters.AddWithValue("@StockActual", p.StockActual);
                cmd.Parameters.AddWithValue("@StockMinimo", p.StockMinimo);
                cmd.Parameters.AddWithValue("@AplicaIva", p.AplicaIva ? 1 : 0);
                cmd.Parameters.AddWithValue("@Estado", p.Estado ? 1 : 0);

                try
                {
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al modificar el producto: " + ex.Message);
                }
            }
        }

        // Eliminación 
        public bool EliminarLogicoProducto(int idProducto)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                string query = "UPDATE Producto SET Estado = 0 WHERE IDProducto = @IDProducto";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IDProducto", idProducto);

                try
                {
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al desactivar el producto: " + ex.Message);
                }
            }
        }
    }
}
