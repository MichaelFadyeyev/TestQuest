using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestQuest.Models
{
    public class Test
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Тема")]
        public string Theme { get; set; }

        [Required]
        [Display(Name = "Предмет")]
        public int SubjectId { get; set; }

        // навігаційні властивості

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        public virtual List<Question> TaskItems { get; set; }
    }
}
