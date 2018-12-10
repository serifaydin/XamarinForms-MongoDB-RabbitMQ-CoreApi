using System.ComponentModel.DataAnnotations.Schema;

namespace MLTP.Infrastructure.DataModels.Models
{
    [Table("MLTP_ROLE")]
    public class MltpRole
    {
        [Column("ID")]
        public virtual int Id { get; set; }

        [Column("NAME")]
        public virtual string Name { get; set; }

        [Column("DESCRIPTION")]
        public virtual string Description { get; set; }
    }
}