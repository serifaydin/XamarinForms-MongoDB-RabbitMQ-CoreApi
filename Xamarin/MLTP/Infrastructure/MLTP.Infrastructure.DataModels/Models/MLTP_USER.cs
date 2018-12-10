using System.ComponentModel.DataAnnotations.Schema;

namespace MLTP.Infrastructure.DataModels.Models
{
    [Table("MLTP_USER")]
    public class MltpUser
    {
        [Column("ID")]
        public virtual int Id { get; set; }

        [Column("USERNAME")]
        public virtual string UserName { get; set; }

        [Column("NAME")]
        public virtual string Name { get; set; }

        [Column("SURNAME")]
        public virtual string Surname { get; set; }

        [Column("EMAIL")]
        public virtual string Email { get; set; }

        [Column("PASSWORD")]
        public virtual string Password { get; set; }

        [Column("GSM")]
        public virtual string Gsm { get; set; }

    }
}
