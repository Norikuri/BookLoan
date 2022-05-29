using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;
using BookLoan.Daos;
using BookLoan.Models;
using BookLoan.Utils;
using BookLoan.Extensions;
using System.Reflection.Metadata.Ecma335;
using System.Xml;

namespace BookLoan.Controllers
{
    public class LoginController: Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult Login(Login account)
        {
            if (ModelState.IsValid)
            {
                var con = DbUtil.GetConnection();
                var dao = new EmployeeDao(con);
                //入力されたユーザーID(メールアドレス)とパスワードで検索
                //DBにデータがあればログイン成功とする
                var list = dao.SelectByMailPass(account.Id, account.Pass);

                if (list.Count == 0)
                {
                    //listの件数が0件だったらログイン失敗
                    //ログイン画面を表示する

                    //ログイン失敗メッセージ設定
                    ModelState.AddModelError(string.Empty, "メールアドレスまたはパスワードが間違っています");

                    return View("Index",account);
                }
                else
                {
                    //取得データをセッションに格納する
                    HttpContext.Session.SetObject<Employee>("ACCOUNT_INFO", list[0]);
                    if (list[0].Flg_admin == "1")
                    {
                        return View("Admin_Menu");
                    }
                    else
                    {
                        return View("General_menu");
                    }
                }
            }
            else
            {
                //入力値が不正だったらログイン画面表示
                return View("Index");
            }                                              
        }

        public IActionResult Index(EmployeeViewModel model)
        {
            // 以下のコメントの処理を埋めて、Model(DAO)の処理を呼んで
            // Viewに渡すmodelを作成する

            // ===== 以下のコメントの処理を埋める
            // EmployeeViewModel型のインスタンスを生成する(変数名はemployeeViewModel)
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            // Modelの中のプロパティを検証する
            if (ModelState.IsValid) // 検証結果OK isValidということは有効ということです
            {
                // DbUtilのGetConnectionメソッドを呼び、SqlConnection型の戻り値を受け取る
                SqlConnection con = DbUtil.GetConnection();
                // EmployeeDaoのインスタンスを生成する
                // 作成する際、コンストラクタの引数にSqlConnection型のインスタンスを渡す
                EmployeeDao dao = new EmployeeDao(con);
                List<Employee> list;
                if (model.SelectId != null && model.SelectId != 0)
                {
                    // Nullableとなっているので、int?→intに変換
                    var id = model.SelectId.Value;
                    // 検索IDが入力されていたら、ID検索
                    list = dao.SelectById(id);
                }
                //else if (!string.IsNullOrEmpty(model.SelectMail))
                //{
                //    // 検索メールアドレスが入力されていたら、メール検索
                //    list = dao.SelectByMail(model.SelectMail);
                //}
                else
                {
                    // DAOのSelectAllメソッドを呼び、List<Employee>型のインスタンスを受け取る
                    list = dao.SelectAll();
                }
                // EmployeeViewModel型のインスタンスのEmpListプロパティに、
                // SelectAllメソッドの戻り値を代入する
                employeeViewModel.EmpList = list;
                // ===== ここまで
            }
            return View(employeeViewModel);
        }

        /// <summary>
        /// CreateEmp画面遷移用
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CreateEmp()
        {
            return View();
        }
        /// <summary>
        /// 社員情報登録用
        /// </summary>
        /// <param name="employee">入力された値で作成されたモデル</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateEmp(Employee employee)
        {
            if (ModelState.IsValid) //入力値検証結果OKの場合は以下の処理を行う
            {
                //DbUtilのGetConnectionメソッドを呼び、SqlConnection型の戻り値を受け取る
                var con = DbUtil.GetConnection();
                //EmployeeDaoのインスタンスを生成する
                //作成する際、コンストラクタの引数にSqlConnection型のインスタンスを渡す
                var dao = new EmployeeDao(con);
                //DAOのInsertEmployeeメソッドを呼ぶ
                //引数にemployee変数を渡す
                dao.InsertEmployee(employee);
            }
            else//入力検証結果NGだったら入力画面にもどる。
            {
                return View(employee);
            }
            //=====
            //リダイレクトの処理
            //このクラスのIndexメソッドを呼ぶ
            //hhtps://localhost:ポート番号/DBAccess/Index
            //
            return RedirectToAction(nameof(Index));
        }



    }
}
