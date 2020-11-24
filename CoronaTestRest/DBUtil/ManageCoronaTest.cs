using CoronaTestRest.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaTestRest.DBUtil
{
    public class ManageCoronaTest
    {
        private const String connectionString = @"Server=tcp:oursqlservice.database.windows.net,1433;Initial Catalog=RestDB;Persist Security Info=False;User ID=Secret!;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private const String Get_All = "select * from CoronaTests";

        public IEnumerable<CoronaTest> Get()
        {
            List<CoronaTest> liste = new List<CoronaTest>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(Get_All, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CoronaTest test = ReadNextElement(reader);
                    liste.Add(test);
                }

                reader.Close();
            }

            return liste;
        }

        private CoronaTest ReadNextElement(SqlDataReader reader)
        {
            CoronaTest coronaTest = new CoronaTest();

            coronaTest.MachineId = reader.GetInt32(0);
            coronaTest.MachineName = reader.GetString(1);
            coronaTest.Temperature = reader.GetDouble(2);
            coronaTest.Location = reader.GetString(3);
            coronaTest.Date = reader.GetString(4);
            coronaTest.Time = reader.GetString(5);

            return coronaTest;
        }
    }
}
