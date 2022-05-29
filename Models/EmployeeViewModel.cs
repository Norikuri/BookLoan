using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLoan.Models
{
    public class EmployeeViewModel
    {
        public List<Employee> EmpList { get; set; } = new List<Employee>();

        // ID検索用のプロパティ
        [Display(Name = "検索ID")]
        //[DisplayName("検索ID")] こっちでもOK
        //[Required(ErrorMessage = "{0}は入力必須です")]
        // 数値の範囲を設定 Range(最小値, 最大値) ※int.MaxValueはint型の最大値
        [Range(10000, int.MaxValue, ErrorMessage = "{0}は10000～の数値を入力してください")]
        public int? SelectId { get; set; }

        [Display(Name = "検索メールアドレス")]
        // 必須チェック
        //[Required(ErrorMessage = "{0}は入力必須です")]
        // メールアドレス形式のチェック
        [EmailAddress(ErrorMessage = "メールアドレスの形式になっていません")]
        public string SelectMail { get; set; }
    }
}
