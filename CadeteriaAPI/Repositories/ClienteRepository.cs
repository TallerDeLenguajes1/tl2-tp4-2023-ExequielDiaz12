using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaAPI.models;
using System.Data;
using System.Data.SQLite;

namespace CadeteriaAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbConnection _dbConnection;
        public ClienteRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public Cliente GetCliente(int id)
        {
            using (var connection = _dbConnection)
            {
                connection.Open();
                var query = "SELECT * FROM Clientes WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, (SQLiteConnection)connection))
                {
                    command.Parameters.Add(new SQLiteParameter("@Id", id));
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cliente
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Apellido = reader["Apellido"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                Telefono = reader["Telefono"].ToString()
                            };
                        }
                        return null;
                    }
                }
            }
        }
        public IEnumerable<Cliente> GetAllClientes()
        {
            using (var connection = _dbConnection)
            {
                connection.Open();
                var query = "SELECT * FROM Clientes";
                using (var command = new SQLiteCommand(query, (SQLiteConnection)connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var clientes = new List<Cliente>();
                        while (reader.Read())
                        {
                            clientes.Add(new Cliente
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Apellido = reader["Apellido"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                Telefono = reader["Telefono"].ToString()
                            });
                        }
                        return clientes;
                    }
                }
            }
        }
        public void CreateCliente(Cliente cliente)
        {
            using (var connection = _dbConnection)
            {
                connection.Open();
                var query = "INSERT INTO Clientes (Apellido, Nombre, Direccion, Telefono) VALUES (@Apellido, @Nombre, @Direccion, @Telefono)";
                using (var command = new SQLiteCommand(query, (SQLiteConnection)connection))
                {
                    command.Parameters.Add(new SQLiteParameter("@Apellido", cliente.Apellido));
                    command.Parameters.Add(new SQLiteParameter("@Nombre", cliente.Nombre));
                    command.Parameters.Add(new SQLiteParameter("@Direccion", cliente.Direccion));
                    command.Parameters.Add(new SQLiteParameter("@Telefono", cliente.Telefono));
                    command.ExecuteNonQuery();
                }
            }
        }
        public bool UpdateCliente(int id, Cliente cliente)
        {
            using (var connection = _dbConnection)
            {
                connection.Open();
                var query = "UPDATE Clientes SET Apellido = @Apellido, Nombre = @Nombre, Direccion = @Direccion, Telefono = @Telefono WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, (SQLiteConnection)connection))
                {
                    command.Parameters.Add(new SQLiteParameter("@Id", id));
                    command.Parameters.Add(new SQLiteParameter("@Apellido", cliente.Apellido));
                    command.Parameters.Add(new SQLiteParameter("@Nombre", cliente.Nombre));
                    command.Parameters.Add(new SQLiteParameter("@Direccion", cliente.Direccion));
                    command.Parameters.Add(new SQLiteParameter("@Telefono", cliente.Telefono));
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public bool DeleteCliente(int id)
        {
            using (var connection = _dbConnection)
            {
                connection.Open();
                var query = "DELETE FROM Clientes WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, (SQLiteConnection)connection))
                {
                    command.Parameters.Add(new SQLiteParameter("@Id", id));
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}