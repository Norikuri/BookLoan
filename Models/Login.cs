using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookLoan.Models
{
    public class Login
    {
        [Display(Name = "社員ID（メールアドレス）")]
        public string Id { get; set; }
        [Display(Name = "パスワード")]
        public string Pass { get; set; }
    }
}
