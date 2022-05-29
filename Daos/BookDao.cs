using BookLoan.Controllers;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Dapper;
using BookLoan.Models;

namespace BookLoan.Daos
{
    public class BookDao : BaseDao<Serch_BKModel>
    {
        public BookDao(SqlConnection con) : base(con) { }
        public BookDao(SqlConnection con, SqlTransaction tran) : base(con, tran) { }

        //DB側の名前群
        private const string TABLE_NAME = "books";
        private const string ISBN_COLUMN = "isbn";
        private const string NAME_COLUMN = "nm_book";
        private const string KANA_COLUMN = "kn_booK";
        private const string PUBLISHER_COLUMN = "publisher";
        private const string ID_UPDATE_COLUMN = "id_update";
        private const string DATE_UPDATE_COLUMN = "date_update";

        public override string GetTableName()
        {
            return TABLE_NAME;
        }

        public override string GetId()
        {
            return ISBN_COLUMN;
        }

        //ISBN検索

        public List<Serch_BKModel> SelectByISBN(string isbn)
        {
            List<Serch_BKModel> list = null;

            string sql = $@"
               SELECT
                    isbn
                    ,nm_book
                    ,kn_booK
                    ,publisher
                    ,id_update
                    ,date_update
               FROM
                    {this.GetTableName()}";

            return list;
        }
    }
}