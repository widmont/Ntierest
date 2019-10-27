using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ClassLibraryDAL
{
    public class FileHandlerDB
    {
        private string connectionString;
        public FileHandlerDB()
        {
            connectionString = "Server=153.109.124.35;Database=NtierDemo;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true";
        }
        public string GetContent(string filename)
        {
            string result = null;
            try
            {

                System.Console.WriteLine("accessing database");
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM FileDemo WHERE Filename = @Filename";


                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Filename", filename);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (dr["Filecontent"] != DBNull.Value)
                                result = (string)dr["Filecontent"];
                        }
                    }
                }
                System.Console.WriteLine("no error");
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            return result;
        }

        public void AddContent(string filename, string content)
        {
            try
            {
                System.Console.WriteLine("accessing database to write -- " + filename + " " + content);

                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO FileDemo(Filename, Filecontent) VALUES(@Filename, @Filecontent)";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@Filename", filename);
                    cmd.Parameters.AddWithValue("@Filecontent", content);

                    cn.Open();

                    cmd.ExecuteNonQuery();


                }
                System.Console.WriteLine("no error");
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

        }
    }
}
