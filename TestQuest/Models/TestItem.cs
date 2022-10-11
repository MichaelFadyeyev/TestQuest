using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestQuest.Models
{
    public class TestItem
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Студент")]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "Екзамен")]
        public int TestId { get; set; }

        public int Score { get; set; }

        // навігаційні властивості
        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }

        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }
    }
}
