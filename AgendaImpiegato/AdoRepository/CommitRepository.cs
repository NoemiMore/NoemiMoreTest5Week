using AgendaImpiegato.Entity;
using AgendaImpiegato.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AgendaImpiegato.Entity.Commit;

namespace AgendaImpiegato.AdoRepository
{
    class CommitRepository : ICommitRepository

    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                       "Initial Catalog = AgendaImpiegato;" +
                                      "Integrated Security = true;";

        public void Delete(Commit t)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Commit where Id = @id";
                command.Parameters.AddWithValue("@id", commit.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Commit> Fetch()
        {
            List<Commit> commits = new List<Commit>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Commit ";
               

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var title = (string)reader["Title"];
                    var description = (string)reader["Description"];
                    var dateExpiration = (DateTime)reader["DateExpiration"];
                    
                    var priority = (_Importance)reader["Priority"];
                    var isFlag= (bool)reader["IsFlag"];
                    var id = (int)reader["Id"];

                    Commit commit  = new Commit(title,description, dateExpiration, priority, isFlag, id);
                    commits.Add(commit);
                }
            }
            return commits;
        }

        public void Insert(Commit commit)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                
                command.CommandText = "insert into Commit values (@title, @description, @dateExpiration, @priority, @isFlag, )";
                command.Parameters.AddWithValue("@title", commit.Title);
                command.Parameters.AddWithValue("@description", commit.Description);
                command.Parameters.AddWithValue("@dateExpiration", commit.DateExpiration);
                command.Parameters.AddWithValue("@priority", commit.Priority);
                command.Parameters.AddWithValue("@isFlag", commit.IsFlag);
              

                command.ExecuteNonQuery();
            }
        }

        public void Update(Commit commit)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Commit " +
                                      "set Title = @title, Description = @description, DateExpiration = @dateExpiration, " +
                                      "Priority = @priority, IsFlag = @IsFlag " +
                                      "where Id = @id";
                command.Parameters.AddWithValue("@title", commit.Title);
                command.Parameters.AddWithValue("@description", commit.Description);
                
                command.Parameters.AddWithValue("@dateExpiration", commit.DateExpiration);
                command.Parameters.AddWithValue("@priority", commit.Priority);
                command.Parameters.AddWithValue("@isFlag", commit.IsFlag);



                command.ExecuteNonQuery();
            }
        
        }
    }
}
