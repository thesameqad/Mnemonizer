using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WCF_DataAccess
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DbService" in code, svc and config file together.
    public class DbService : IDbService, IDisposable
    {
        public void DoWork()
        {
        }
        private SqlConnection connection;
        public DbService()
        {
            SqlConnectionStringBuilder connectionstrin = new SqlConnectionStringBuilder();
            connectionstrin.DataSource = @"1-ПК\SQLEXPRESS";
            connectionstrin.InitialCatalog = "Dictionary";
            connectionstrin.IntegratedSecurity = true;
            connection = new SqlConnection(connectionstrin.ConnectionString);
            connection.Open();
           
        }
       
        public int GetId(string NameWord)
        {
            string query = "SELECT ID FROM Words WHERE word=@NameWord"; 
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter()
            {
                DbType = DbType.String,
                Value = NameWord,
                ParameterName = "NameWord"
            }); 
           
            SqlDataReader dataReader = command.ExecuteReader();
            int Id=0;
            while (dataReader.Read())
            {
                Id = dataReader.GetInt32(0);          
            }
            dataReader.Close();
            return Id;
        }
        public string GetWord(int Id)
        {
            string query = "SELECT word FROM Words WHERE ID=@id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter()
            {
                DbType = DbType.Int32,
                Value = Id,
                ParameterName = "id"
            });
            string Word="";
            SqlDataReader dataReader = command.ExecuteReader();
           
            while (dataReader.Read())
            {
                Word = dataReader.GetString(0);
            }
            dataReader.Close();
            return Word;
        }
        public void Dispose()
        {
            connection.Close();
        }
    }
}
