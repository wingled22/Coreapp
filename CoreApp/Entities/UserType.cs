using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreApp.Entities
{
    public partial class UserType
    {
        public UserType()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
