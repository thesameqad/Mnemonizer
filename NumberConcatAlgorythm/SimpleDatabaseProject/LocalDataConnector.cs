using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SimpleDatabaseProject
{
    public class LocalDataConnector
    {
        private SampleDatabaseEntities DatabaseContent;


        public void insertToTable(string NameWord)
        {

            DatabaseContent = new SampleDatabaseEntities(@"Data Source=C:\Users\Yana\Desktop\NumberConcatAlgorythm\SimpleDatabaseProject\SampleDatabase.sdf");
            //запрос на запонение БД
            //LINQ insert

            /*try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=C:\Users\1\Desktop\mnemonizer\NumberConcatAlgorythm\SimpleDatabaseProject\SampleDatabase.sdf");
                connection.Open();

                string query = "INSERT INTO Words (Word) VALUES (@NameWord)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.String,
                    Value = NameWord,
                    ParameterName = "NameWord"
                });

                int id = command.ExecuteNonQuery();
            }
            catch (Exception e)
            { 
                
            }
            */
        }
    }
}
