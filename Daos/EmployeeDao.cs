using BookLoan.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
namespace BookLoan.Daos
{
    public class EmployeeDao : BaseDao<Employee>
    {
        public EmployeeDao(SqlConnection con) : base(con) { }
        public EmployeeDao(SqlConnection con, SqlTransaction tran) : base(con, tran) { }

        // DB側の名前群
        private const string TABLE_NAME = "employee";
        private const string ID_COLUMN = "id_employee";
        private const string NAME_COLUMN = "nm_employee";
        private const string KANA_COLUMN = "kn_employee";
        private const string MAIL_COLUMN = "mail_address";
        private const string PASS_COLUMN = "password";
        private const string ID_D_COLUMN = "id_department";
        private const string FLG_ADMIN_COLUMN = "flg_admin";
        private const string FLG_RETIREMENT_COLUMN = "flg_retirment";
        private const string ID_UPDATE_COLUMN = "id_update";
        private const string DATE_UPDATE_COLUMN = "date_update";

        public override string GetTableName()
        {
            return TABLE_NAME;
        }

        public override string GetId()
        {
            return ID_COLUMN;
        }

        public List<Employee> SelectByMailPass(string mail, string pass)
        {
            List<Employee> list = null;

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
                    {MAIL_COLUMN} = @Mail_address
                AND
                    {PASS_COLUMN} = @Password
            ";

            // Dapper導入のため削除
            /* SqlCommand cmd = new SqlCommand(sql, this.Con);
            SetParameter(cmd, "@mail", mail);
            SetParameter(cmd, "@pass", pass);
            list = ExecuteSelectSql(cmd);*/
            list = (List<Employee>)this.Con.Query<Employee>(sql, new Employee { Mail_address = mail, Password = pass });

            return list;
        }

   
        private string EncodeForLike(string word)
        {
            return word.Replace("[", "[[]").Replace("%", "[%]");
        }

        /// <summary>
        /// 挿入処理
        /// </summary>
        /// <param name="employee">挿入したいデータをセットするエンティティ</param>
        public void InsertEmployee(Employee employee)
        {
            /* 
             * StringBuilderでSQL作成
             * 性能は良いが、ちょい見にくくなるし書くのが大変
             * AppendLineで書くと改行されて見やすくなる
             */
            var sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + this.GetTableName());
            sql.AppendLine("(");
            sql.AppendLine("     nm_employee");
            sql.AppendLine("    ,kn_employee");
            sql.AppendLine("    ,mail_address");
            sql.AppendLine("    ,password");
            sql.AppendLine("    ,id_department");
            sql.AppendLine(") VALUES (");

            // Dapper対応　パラメータ名をプロパティ名と一緒にする
            sql.AppendLine($"     @NmEmployee");
            sql.AppendLine($"    ,@{KANA_COLUMN}");
            sql.AppendLine($"    ,@{MAIL_COLUMN}");
            sql.AppendLine($"    ,@{PASS_COLUMN}");
            sql.AppendLine($"    ,@{ID_D_COLUMN}");
            sql.AppendLine(")");

            // DapperでSQL実行
            /*
             * 更新系(INSERT, UPDATE, DELETE)はExecuteメソッドで実行
             * 第一引数：SQL
             * 第二引数：パラメータ設定(今回はEmployee型)
             * 第三引数：トランザクション（「transaction:」というのは引数名を指定して渡すことができる。あってもなくてもいい。）
             * 戻り値：処理した行数
             */
            var count = this.Con.Execute(sql.ToString(), employee, transaction: this.SqlTran);

            // Dapper導入のため削除
            /*            var cmd = new SqlCommand(sql.ToString(), this.Con);
                        cmd.Transaction = SqlTran;

                        SetParameter(cmd, "@name", employee.nm_employee);
                        SetParameter(cmd, "@kana", employee.kn_employee);
                        SetParameter(cmd, "@mail", employee.mail_address);
                        SetParameter(cmd, "@pass", employee.password);
                        SetParameter(cmd, "@dep", employee.id_employee.Value);

                        // SQL実行
                        cmd.ExecuteNonQuery();*/
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="id">更新したいID</param>
        /// <param name="employee">挿入したいデータをセットするエンティティ</param>
        public void UpdatetEmployee(int id, Employee employee)
        {
            string sql = $@"
                UPDATE {this.GetTableName()}
                SET
                     { NAME_COLUMN} = @NmEmployee
                    ,{ KANA_COLUMN} = @{KANA_COLUMN}
                    ,{ MAIL_COLUMN} = @{MAIL_COLUMN}
                    ,{ PASS_COLUMN} = @{PASS_COLUMN}
                    ,{ ID_D_COLUMN} = @{ID_D_COLUMN}
                WHERE
                    {ID_COLUMN} = @id
            ";

            var count = this.Con.Execute(sql.ToString(), employee, transaction: this.SqlTran);

        }
    }
}
