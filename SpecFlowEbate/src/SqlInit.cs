namespace SpecFlowEbate.src
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Text;
    using SpecFlowTest;

    namespace sqltest
    {
        class SqlInit
        {
        private static readonly Credentials credentials = new Credentials();
        public decimal calculatedValue;


            public string SqlConnector(string query)
            {

                try
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    DataTable dataTable = new DataTable();

                    builder.DataSource = credentials.SQLDataSource;
                    builder.UserID = credentials.SQLUserID;
                    builder.Password = credentials.SQLPassword;
                    builder.InitialCatalog = credentials.SQLInitialCatalog;

                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {   
                        StringBuilder sb = new StringBuilder();
                        sb.Append(query);
                        String sql = sb.ToString();

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            connection.Open();
                            SqlDataAdapter da = new SqlDataAdapter(command);
                            da.Fill(dataTable);
                            DataRow[] rows = dataTable.Select();
                            for (int i = 0; i < rows.Length; i++)
                            {
                                calculatedValue = (decimal)rows[i]["CalculatedValue"];
                            }
                            connection.Close();
                            da.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return calculatedValue.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            }
        }
    }
}
