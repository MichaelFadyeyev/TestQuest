using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestQuest.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Предмет")]
        public string Title { get; set; }

        // навігаційні властивості

        public virtual List<Test> Tests { get; set; }
    }
}