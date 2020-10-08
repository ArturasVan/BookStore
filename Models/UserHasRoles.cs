using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class UserHasRoles
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RoleId { get; set; }

        public virtual AppUserRoles Role { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
