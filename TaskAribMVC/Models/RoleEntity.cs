using Microsoft.AspNetCore.Identity;

namespace TaskAribMVC.Models
{
    public class RoleEntity : IdentityRole
    {

        #region Base Data

        public string CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }

        public string DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }

        public string LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }

        #endregion
    }

}
