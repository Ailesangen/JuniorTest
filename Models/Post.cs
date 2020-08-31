using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;    

namespace EmplDBA.API.Models
{
    public class Post
    {
        [Key]
        public long PostID { get; set; }

        [StringLength(60)]
        [Display(Name = "Название должности")]
        public string PostName { get; set; }
    }
}
