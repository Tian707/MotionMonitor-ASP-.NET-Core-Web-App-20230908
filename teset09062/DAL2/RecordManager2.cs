using System.Data.SqlClient;
using System.Diagnostics;

namespace teset09062.DAL2
{
    public class RecordManager2
    {
        
        // cannot use AppSettings
        //string connectionString = ConfigurationManager.AppSettings["MyConn"];
        string connectionString = @"Data Source=ZBC-S-tian0247\SQLEXPRESS;Initial Catalog=MotionDetector;Integrated Security=True";

        /// <summary>
        /// Get all records from database
        /// save in a list records
        /// </summary>
        /// <returns></returns>
        public Record2[] GetAllRecords()
        {
            string selectAllRecords = "SELECT * FROM Distances";

            List<Record2> records = new List<Record2>();

            // Connect- database and save each record into list records
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(selectAllRecords, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Record2 record2 = new Record2
                                {
                                    ID = int.Parse(reader["ID"].ToString()),
                                    DistanceInCM = float.Parse(reader["DistanceInCM"].ToString()),
                                    LightCount = int.Parse(reader["LightCount"].ToString()),
                                    ReceivingTime = reader["ReceivingTime"].ToString()
                                };

                                records.Add(record2);
                            }
                        }
                    }
                }
                return records.ToArray();
            }
            catch (SqlException)
            {
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error inserting data into the database: " + ex.Message);
                return null;
            }
        }
    }
}
