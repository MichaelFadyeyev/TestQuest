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
        [Display(Name = "Тест")]
        public int TestId { get; set; }
        [Required]
        [Display(Name = "Питання")]
        public string QuestionText { get; set; }

        [Required]
        [Display(Name = "Вірна відповідь")]
        public int RightAnserNumber { get; set; }

        // навігаційні властивості

        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }
        public virtual List<Answer> Answers { get; set; }

    }
}
