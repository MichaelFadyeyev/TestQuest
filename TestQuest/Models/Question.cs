using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestQuest.Models
{
    public class Question
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Предмет")]
        public int SublectId { get; set; }
        [Required]
        [Display(Name = "Питання")]
        public string QuestionText { get; set; }
        [Required]
        [Display(Name = "Вірна відповідь")]
        public int AnswerId { get; set; }

        // навігаційні властивості

        [ForeignKey("SublectId")]
        public virtual Subject Subject { get; set; }

        [ForeignKey("AnswerId")]
        public virtual Answer Answer { get; set; }
        public virtual List<Answer> Answers { get; set; }

    }
}
