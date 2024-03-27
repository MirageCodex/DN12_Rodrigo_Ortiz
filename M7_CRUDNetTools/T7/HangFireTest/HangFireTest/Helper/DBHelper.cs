using MySqlConnector;

namespace HangFireTest.Helper
{
    public class DBHelper
    {
        private static readonly string connectionString = "server=localhost;port=3306;database=hfexample;user=root;password=asdf1234;Charset=utf8;";

        public static void Process(int milliseconds, string args)
        {
            Thread.Sleep(milliseconds);

            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                mySqlConnection.Open();
                MySqlCommand command = new MySqlCommand("insert into hftest (date,args) values (@date, @args)", mySqlConnection);

                command.Parameters.AddWithValue("@date", DateTime.Now);
                command.Parameters.AddWithValue("@args", args);

                command.ExecuteNonQuery();
            }
        }
    }
}
