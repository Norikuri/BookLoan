using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BookLoan.Models;
using Dapper;

namespace BookLoan.Daos
{
    public abstract class BaseDao<T>
    {
        protected SqlConnection Con { get; private set; }
        protected SqlTransaction SqlTran { get; private set; }

        protected BaseDao(SqlConnection Con)
        {
            this.Con = Con;
        }
        protected BaseDao(SqlConnection Con, SqlTransaction SqlTran)
        {
            this.Con = Con;
            this.SqlTran = SqlTran;
        }

        /// <summary>
        /// 全件検索
        /// </summary>
        /// <returns>取得した結果 T型のリスト</returns>
        public List<T> SelectAll()
        {
            //SqlCommand cmd = null;
            List<T> list = null;

            string sql = $@"
                SELECT
                    *
                FROM
                    {this.GetTableName()}
            ";

            list = (List<T>)this.Con.Query<T>(sql);

            // Dapper導入のため削除
            /*cmd = new SqlCommand(sql, this.Con);
            retList = ExecuteSelectSql(cmd);*/

            // 検索結果をリターン
            return list;
        }

        /// <summary>
        /// ID検索
        /// </summary>
        /// <param name="id">検索するID</param>
        /// <returns>取得した結果 T型のリスト</returns>
        public List<T> SelectById(int id)
        {
            List<T> list = null;

            /*
             * 逐次文字列で作成
             * 見やすいが、処理を挟む場合はStringBuilderが良い
             */
            string sql = $@"
                SELECT
                    *
                FROM
                    {this.GetTableName()}
                WHERE
                    {this.GetId()} = @ID
            ";

            // 匿名クラスでも動く(名前のないクラス)
            list = (List<T>)this.Con.Query<T>(sql, new { ID = id });

            // Dapper導入のため削除
            /*            SqlCommand cmd = new SqlCommand(sql, this.Con);
                        SetParameter(cmd, "@id", id);
                        list = ExecuteSelectSql(cmd);*/
            return list;
        }

        public abstract string GetTableName();
        public abstract string GetId();

        // Dapper導入のため削除
        //protected abstract T RowMapping(SqlDataReader reader);
    }
}
