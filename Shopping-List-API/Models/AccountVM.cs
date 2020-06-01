using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Models
{
    public class AccountVM
    {
        [Key]
        public int AccountId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
