using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLoan.Models
{
    public class Employee
    {
        [Display(Name = "社員ID")]
        public int? Id_employee { get; set; }
        [Display(Name = "社員名")]
        [Required(ErrorMessage = "{0}を入力してください")]
        public string Km_employee { get; set; }
        [Display(Name = "社員名カナ")]
        [Required(ErrorMessage = "{0}を入力してください")]
        public string Kn_employee { get; set; }
        [Display(Name = "メールアドレス")]
        [Required(ErrorMessage = "{0}を入力してください")]
        [EmailAddress]
        public string Mail_address { get; set; }
        [Display(Name = "パスワード")]
        [Required(ErrorMessage = "{0}を入力してください")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "部署ID")]
        [Required(ErrorMessage = "{0}を入力してください")]
        public int? Id_department { get; set; }

        [Display(Name = "管理者フラグ")]
        [Required(ErrorMessage = "{0}を入力してください")]
        public string Flg_admin { get; set; }

        [Display(Name = "退職者フラグ")]
        [Required(ErrorMessage = "{0}を入力してください")]
        public int? Flg_retirement { get; set; }
    }
}
