using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaAPI.models;
using System.Data;
using System.Data.SQLite;

namespace CadeteriaAPI.Repositories
{
    
        public class PedidoRepository : IPedidoRepository
        {
            private readonly IDbConnection _dbConnection;
            public PedidoRepository(IDbConnection dbConnection)
            {
                _dbConnection = dbConnection;
            }
            public Pedido GetPedido(int id)
            {
                using (var connection = _dbConnection)
                {
                    connection.Open();
                    var query = "SELECT * FROM Pedidos WHERE Id = @Id";
                    using (var command = new SQLiteCommand(query, (SQLiteConnection)connection))
                    {
                        command.Parameters.Add(new SQLiteParameter("@Id", id));
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Pedido
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Producto = reader["Producto"].ToString(),
                                    Descripcion = reader["Descripcion"].ToString(),
                                    Estado = reader["Estado"].ToString(),
                                    IdCliente = Convert.ToInt32(reader["IdCliente"]),
                                    IdCadete = Convert.ToInt32(reader["IdCadete"])
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            public IEnumerable<Pedido> GetAllPedidos()
            {
                using (var connection = _dbConnection)
                {
                    connection.Open();
                    var query = "SELECT * FROM Pedidos";
                    using (var command = new SQLiteCommand(query, (SQLiteConnection)connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            var pedidos = new List<Pedido>();
                            while (reader.Read())
                            {
                                pedidos.Add(new Pedido
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Producto = reader["Producto"].ToString(),
                                    Descripcion = reader["Descripcion"].ToString(),
                                    Estado = reader["Estado"].ToString(),
                                    IdCliente = Convert.ToInt32(reader["IdCliente"]),
                                    IdCadete = Convert.ToInt32(reader["IdCadete"])
                                });
                            }
                            return pedidos;
                        }
                    }
                }
            }
            public void CreatePedido(Pedido pedido)
            {
                using (var connection = _dbConnection)
                {
                    connection.Open();
                    var query = "INSERT INTO Pedidos (Producto, Descripcion, Estado, IdCliente, IdCadete) VALUES (@Producto, @Descripcion, @Estado, @IdCliente, @IdCadete); SELECT CAST(SCOPE_IDENTITY() as int)";
                    using (var command = new SQLiteCommand(query, (SQLiteConnection)connection))
                    {
                        command.Parameters.Add(new SQLiteParameter("@Producto", pedido.Producto));
                        command.Parameters.Add(new SQLiteParameter("@Descripcion", pedido.Descripcion));
                        command.Parameters.Add(new SQLiteParameter("@Estado", pedido.Estado));
                        command.Parameters.Add(new SQLiteParameter("@IdCliente", pedido.IdCliente));
                        command.Parameters.Add(new SQLiteParameter("@IdCadete", pedido.IdCadete));
                        command.ExecuteNonQuery();
                    }
                }
            }
            public bool UpdatePedido(int id, Pedido pedido)
            {
                using (var connection = _dbConnection)
                {
                    connection.Open();
                    var query = "UPDATE Pedidos SET Producto = @Producto, Descripcion = @Descripcion, Estado = @Estado, IdCliente = @IdCliente, IdCadete = @IdCadete WHERE Id = @Id";
                    using (var command = new SQLiteCommand(query, (SQLiteConnection)connection))
                    {
                        command.Parameters.Add(new SQLiteParameter("@Producto", pedido.Producto));
                        command.Parameters.Add(new SQLiteParameter("@Descripcion", pedido.Descripcion));
                        command.Parameters.Add(new SQLiteParameter("@Estado", pedido.Estado));
                        command.Parameters.Add(new SQLiteParameter("@IdCliente", pedido.IdCliente));
                        command.Parameters.Add(new SQLiteParameter("@IdCadete", pedido.IdCadete));
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            public bool DeletePedido(int id)
            {
                using (var connection = _dbConnection)
                {
                    connection.Open();
                    var query = "DELETE FROM PEdidos WHERE Id = @Id";
                    using (var command = new SQLiteCommand(query, (SQLiteConnection)connection))
                    {
                        command.Parameters.Add(new SQLiteParameter("@Id", id));
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            public IEnumerable<Pedido> GetPedidoCliente(int idCliente)
            {
                using (var connection = _dbConnection)
                {
                    connection.Open();
                    var query = "SELECT * FROM Pedidos WHERE IdCliente = @IdCliente";
                    using (var command = new SQLiteCommand(query, (SQLiteConnection)connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            var pedidos = new List<Pedido>();
                            while (reader.Read())
                            {
                                pedidos.Add(new Pedido
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Producto = reader["Producto"].ToString(),
                                    Descripcion = reader["Descripcion"].ToString(),
                                    Estado = reader["Estado"].ToString(),
                                    IdCliente = Convert.ToInt32(reader["IdCliente"]),
                                    IdCadete = Convert.ToInt32(reader["IdCadete"])
                                });
                            }
                            return pedidos;
                        }
                    }
                }
            }
        
        }
    
}