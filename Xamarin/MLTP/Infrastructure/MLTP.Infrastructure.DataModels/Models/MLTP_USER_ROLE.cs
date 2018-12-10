using System.ComponentModel.DataAnnotations.Schema;

namespace MLTP.Infrastructure.DataModels.Models
{
    [Table("MLTP_USER_ROLE")]
    public class MltpUserRole
    {
        [Column("ID")]
        public virtual int Id { get; set; }

        [Column("USER_ID")]
        public virtual int UserId { get; set; }

        [Column("ROLE_ID")]
        public virtual int RoleId { get; set; }
    }
}