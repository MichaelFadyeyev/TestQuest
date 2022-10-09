using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestQuest.Models
{
    public class Answer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string AnswerText { get; set; }

        [Required]
        public int QuestionId { get; set; }

        // навігаційні властивості

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
    }
}
