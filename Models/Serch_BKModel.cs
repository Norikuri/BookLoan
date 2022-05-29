using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BookLoan.Models
{
    public class Serch_BKModel
    {
        public List<Books> BkList { get; set; } = new List<Books>();


        // 書籍名検索プロパティ
        [Display(Name = "書籍名 ")]
        public string SelectNmBook { get; set; }
        
        //出版社検索プロパティ
        [Display(Name = "出版社名")]
        public string SelectPublisher { get; set; }

        //特記事項検索プロパティ
        [Display(Name = "特記事項")]
        public string SelectNote { get; set; }

    }
}
