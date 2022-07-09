using MySqlConnector;
namespace AngularRegistarion
{
    public class DbConnection : IDisposable
    {
        MySqlConnector.MySqlConnection conn = null;
        public MySqlConnector.MySqlTransaction transaction_conn = null;

        public MySqlDataReader current_reader = null;

        public DbConnection()
        {
            conn = new MySqlConnector.MySqlConnection();
            conn.ConnectionString = "server = 127.0.0.1; user = root; password = danik123; database = angulartest";

        }

        public int open_connection()
        {
            try
            {
                conn.Open();
                System.Diagnostics.Debug.WriteLine("data base opend");
                return 1;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            return 0;

        }


        public MySqlConnector.MySqlTransaction begin_transaction()
        {

            transaction_conn = conn.BeginTransaction();
            return transaction_conn;
        }


        public int commit_transaction()
        {

            transaction_conn.Commit();
            return 1;
        }

        public int close_connection()
        {
            try
            {
                conn.Close();
                System.Diagnostics.Debug.WriteLine("DB is closed");
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
            return 0;
        }


        public bool read_rows_by_qry(string qry, Dictionary<string, object> prms, MySqlConnector.MySqlTransaction transaction1)
        {

            if (current_reader == null)
            {
                MySqlCommand cmd = new MySqlCommand(qry, conn);


                if (prms != null)
                {


                    string[] keys1 = new string[prms.Keys.Count];
                    prms.Keys.CopyTo(keys1, 0);

                    int i1;

                    for (i1 = 0; i1 < keys1.Length; i1++)
                    {
                        MySqlConnector.MySqlParameter prm1 = new MySqlConnector.MySqlParameter();
                        prm1.ParameterName = keys1[i1];
                        prm1.Value = prms[keys1[i1]];

                        cmd.Parameters.Add(prm1);
                    }
                }
                if (transaction1 != null)
                {
                    cmd.Transaction = transaction1;

                }

                current_reader = cmd.ExecuteReader();

            }
            bool res1 = current_reader.Read();

            if (!res1)
            {
                current_reader.Close();
                current_reader = null;

                return false;
            }


            return true;
        }

        public bool userNameCheck(string qry)
        {
            MySqlCommand myCommand = new MySqlCommand(qry, conn);
            MySqlDataReader dr;
            dr = myCommand.ExecuteReader();
            if (dr.Read())
            {
                return true; // if username is taken
            }
            return false;
        }


        public int execute_query(string qry, Dictionary<string, object> prms, MySqlConnector.MySqlTransaction transaction1)
        {
            MySqlConnector.MySqlCommand cmd = new MySqlConnector.MySqlCommand();
            cmd.CommandText = qry;

            if (prms != null)
            {


                string[] keys1 = new string[prms.Keys.Count];
                prms.Keys.CopyTo(keys1, 0);

                int i1;

                for (i1 = 0; i1 < keys1.Length; i1++)
                {
                    MySqlConnector.MySqlParameter prm1 = new MySqlConnector.MySqlParameter();
                    prm1.ParameterName = keys1[i1];
                    prm1.Value = prms[keys1[i1]];

                    cmd.Parameters.Add(prm1);
                }
            }
            if (transaction1 != null)
            {
                cmd.Transaction = transaction1;

            }
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();

            return 1;
        }

        public void Dispose()
        {
            if (current_reader != null)
            {
                current_reader.Close();
            }

            close_connection();
        }
    }
}
