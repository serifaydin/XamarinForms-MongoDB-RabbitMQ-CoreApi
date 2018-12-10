using System.ComponentModel.DataAnnotations.Schema;

namespace MLTP.Infrastructure.DataModels.Models
{
    [Table("MLTP_ROLE_MENU")]
    public class MltpRoleMenu
    {
        [Column("ID")]
        public virtual int Id { get; set; }

        [Column("ROLE_ID")]
        public virtual int RoleId { get; set; }

        [Column("MENU_ID")]
        public virtual int MenuId { get; set; }
    }
}