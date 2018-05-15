using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Xml;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("getItAll", conn) { CommandType = System.Data.CommandType.StoredProcedure };

            XmlReader reader = command.ExecuteXmlReader();

            string val = reader.ReadOuterXml();
            conn.Close();
            conn.Dispose();

            Console.WriteLine(val);
        }
    }
}
