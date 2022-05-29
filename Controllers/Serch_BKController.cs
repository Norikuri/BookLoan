    using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BookLoan.Daos;
using BookLoan.Models;
using BookLoan.Utils;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;

namespace BookLoan.Controllers
{
    public class Serch_BKController : Controller
    {

        public IActionResult Index()
        {

            SqlConnection con = DbUtil.GetConnection();
            Books books = new Books();

            //　変更点
            Serch_BKModel serchBK = new Serch_BKModel();


            string sql = "SELECT books.nm_book, books.publisher, book_collection.note FROM books INNER JOIN book_collection ON books.isbn = book_collection.isbn WHERE book_collection.fig_disposal = '0'";
            var list = (List<Books>)con.Query<Books>(sql, books);

            serchBK.BkList = list;

            return View(serchBK);

            //---以下今は使わないコード---//

            ////入力された書籍名とISBN
            //var SelectNmBook = Request.Form["SelectNmBook"];
            //var SelectISBN = Request.Form["SelectISBN"];

            ////DbutilのGetConnection型のメソッドを呼び、SqlConnection型の戻り値を受け取る
            //SqlConnection bk = DbUtil.GetConnection();
            //List<Books> bok = null;
            ////BookViewModel型のインスタンスの生成
            //BookViewModel bookViewModel = new BookViewModel();



            // 以下のコメントの処理を埋めて、Model(DAO)の処理を呼んで
            // Viewに渡すmodelを作成する

            //// ===== 以下のコメントの処理を埋める
            //// EmployeeViewModel型のインスタンスを生成する(変数名はemployeeViewModel)
            //EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            //// Modelの中のプロパティを検証する
            //if (ModelState.IsValid) // 検証結果OK isValidということは有効ということです
            //{
            //    // DbUtilのGetConnectionメソッドを呼び、SqlConnection型の戻り値を受け取る
            //    SqlConnection con = DbUtil.GetConnection();
            //    // EmployeeDaoのインスタンスを生成する
            //    // 作成する際、コンストラクタの引数にSqlConnection型のインスタンスを渡す
            //    EmployeeDao dao = new EmployeeDao(con);

            //    Employee emp = new Employee
            //    {
            //        Id_employee = model.SelectId,
            //        Mail_address = model.SelectMail
            //    };
            //    var list = dao.SelectByAllParam(emp); ;

            //    // EmployeeViewModel型のインスタンスのEmpListプロパティに、
            //    // SelectAllメソッドの戻り値を代入する
            //    employeeViewModel.EmpList = list;
            //    // ===== ここまで


            

           
        }
         //書籍名検索
        [HttpPost]
        public IActionResult Index(string SelectNmBook,string SelectNote,string SelectPublisher)
        {
            SqlConnection con = DbUtil.GetConnection();

            //Books books = new Books();

            Serch_BKModel serchBK1 = new Serch_BKModel();

            //SQL文(クエリ)を用意

            var query = "";
            List<Books> books = new List<Books>();
            if(!string.IsNullOrEmpty(SelectNmBook)) //書籍名検索
            {
                query = @$"SELECT 
                                books.nm_book
                               ,books.publisher
                               ,book_collection.note 
                            FROM 
                                books INNER JOIN 
                                book_collection 
                                   ON books.isbn = book_collection.isbn 
                                    WHERE books.nm_book LIKE '%' + @NmBook + '%'";
                books = (List<Books>)con.Query<Books>(query, new { NmBook = SelectNmBook });
            }
            else if(!string.IsNullOrEmpty(SelectNote))//特記事項検索
            {
                query = @$"SELECT 
                                books.nm_book
                               ,books.publisher
                               ,book_collection.note 
                            FROM 
                                books INNER JOIN 
                                book_collection 
                                   ON books.isbn = book_collection.isbn 
                                    WHERE CAST (book_collection.note as char(120)) LIKE '%' +  @Note + '%'";

                books = (List<Books>)con.Query<Books>(query, new { Note = SelectNote });
            }
            else if(!string.IsNullOrEmpty(SelectPublisher)) //出版社検索
            {
                query = @$"SELECT 
                                books.nm_book
                               ,books.publisher
                               ,book_collection.note 
                            FROM 
                                books INNER JOIN 
                                book_collection 
                                   ON books.isbn = book_collection.isbn 
                                    WHERE books.publisher LIKE '%' + @Company + '%'";

                books = (List<Books>)con.Query<Books>(query, new {Company = SelectPublisher });
            }


            serchBK1.BkList = books;
            
            /*
             * 画面を表示する
             * その際、serchBK1というモデルを画面側に渡す
             */
            return View(serchBK1);

        }

        public IActionResult IndexMenu()
        {
            return RedirectToAction("Login", "Login");
        }



    }
}

