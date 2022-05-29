using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLoan.Models
{
    public class Books
    {
        

        //書籍マスターテーブル
        [Display(Name = "ISBN")]
        public string Isbn { get; set; }
        [Display(Name = "書籍名")]
        [Required(ErrorMessage = "{0}を入力してください")]
        public string Nm_book { get; set; }
        [Display(Name = "書籍名よみ")]
        [Required(ErrorMessage = "{0}を入力してください")]
        public string Kn_book { get; set; }
        [Display(Name = "出版社")]
        [Required(ErrorMessage = "{0}を入力してください")]
        [EmailAddress]
        public string Publisher { get; set; }
        [Display(Name = "更新者")]
        [Required(ErrorMessage = "{0}を入力してください")]
        public int Id_update { get; set; }
        [Display(Name = "更新日")]
        [Required(ErrorMessage = "{0}を入力してください")]
        public string Date_update { get; set; }

        //蔵書マスタテーブル

        [Display(Name = "蔵書ID")]
        [Required(ErrorMessage = "{0}を入力してください")]
        public string id_book { get; set; }

        [Display(Name = "ISBN")]
        [Required(ErrorMessage = "{0}を入力してください")]
        public string isbn { get; set; }

        [Display(Name = "特記事項")]
        [Required(ErrorMessage = "{0}を入力してください")]
        public string note { get; set; }

        [Display(Name = "廃棄フラグ")]
        [Required(ErrorMessage = "{0}を入力してください")]
        public string disposal { get; set; }

        [Display(Name = "更新者")]
        [Required(ErrorMessage = "{0}を入力してください")]
        public int id_update { get; set; }

        [Display(Name = "更新日")]
        [Required(ErrorMessage = "{0}を入力してください")]
        public string date_update { get; set; }
    }
}

