using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MovieProject.Persistance.Identity
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string surname { get; set; }
        public string? ImageUrl { get; set; }
    }
}
