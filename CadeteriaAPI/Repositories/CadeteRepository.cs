using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaAPI.models;
using System.Data;
using System.Data.SQLite;

namespace CadeteriaAPI.Repositories
{
    public class CadeteRepository : ICadeteRepository
    {
        private readonly IDbConnection _dbConnection;
        public CadeteRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public Cadete GetCadete(int id)
        {
            using (var connection = _dbConnection)
            {
                connection.Open();
                var query = "SELECT * FROM Cadetes WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, (SQLiteConnection)connection))
                {
                    command.Parameters.Add(new SQLiteParameter("@Id", id));
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cadete
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                Domicilio = reader["Domicilio"].ToString(),
                                Telefono = reader["Telefono"].ToString()
                            };
                        }
                        return null;
                    }
                }
            }
        }
        public IEnumerable<Cadete> GetAllCadetes()
        {
            using (var connection = _dbConnection)
            {
                connection.Open();
                var query = "SELECT * FROM Cadetes";
                using (var command = new SQLiteCommand(query, (SQLiteConnection)connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var cadetes = new List<Cadete>();
                        while (reader.Read())
                        {
                            cadetes.Add(new Cadete
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                Domicilio = reader["Domicilio"].ToString(),
                                Telefono = reader["Telefono"].ToString()
                            });
                        }
                        return cadetes;
                    }
                }
            }
        }
        public void CreateCadete(Cadete cadete)
        {
            using (var connection = _dbConnection)
            {
                connection.Open();
                var query = "INSERT INTO Cadetes (Nombre, Domicilio, Telefono) VALUES (@Nombre, @Domicilio, @Telefono)";
                using (var command = new SQLiteCommand(query, (SQLiteConnection)connection))
                {
                    command.Parameters.Add(new SQLiteParameter("@Nombre", cadete.Nombre));
                    command.Parameters.Add(new SQLiteParameter("@Domicilio", cadete.Domicilio));
                    command.Parameters.Add(new SQLiteParameter("@Telefono", cadete.Telefono));
                    command.ExecuteNonQuery();
                }
            }
        }
        public bool UpdateCadete(int id, Cadete cadete)
        {
            using (var connection = _dbConnection)
            {
                connection.Open();
                var query = "UPDATE Cadetes SET Nombre = @Nombre, Domicilio = @Domicilio, Telefono = @Telefono WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, (SQLiteConnection)connection))
                {
                    command.Parameters.Add(new SQLiteParameter("@Id", id));
                    command.Parameters.Add(new SQLiteParameter("@Nombre", cadete.Nombre));
                    command.Parameters.Add(new SQLiteParameter("@Domicilio", cadete.Domicilio));
                    command.Parameters.Add(new SQLiteParameter("@Telefono", cadete.Telefono));
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public bool DeleteCadete(int id)
        {
            using (var connection = _dbConnection)
            {
                connection.Open();
                var query = "DELETE FROM Cadetes WHERE Id = @Id";
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