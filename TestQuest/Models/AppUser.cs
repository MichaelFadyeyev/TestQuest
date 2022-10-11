using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace TestQuest.Models
{
    public class AppUser : IdentityUser
    {      
        // навігаційні властивості
        public virtual List<TestItem> TestItems { get; set; }
    }
}
