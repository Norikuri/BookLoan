using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BookLoan.Utils
{
    public static class DbUtil
    {
        private static SqlConnection con;

        // appsettings.jsonから取得したConnectionStringを保存する用
        public static string ConnectionString { get; set; }

        public static SqlConnection GetConnection()
        {
            // appsettings.jsonからうまくConnectionStringが取得できなかった場合
            if (string.IsNullOrEmpty(ConnectionString))
            {
                // エラーとする
                throw new Exception("DB設定がされていません");
            }

            con = new SqlConnection()
            {
                ConnectionString = ConnectionString
            };
            con.Open();
            return con;
        }

        public static void CloseConnection(SqlConnection sqlCon)
        {
            if (sqlCon != null)
            {
                sqlCon.Close();
            }
        }
    }
}
