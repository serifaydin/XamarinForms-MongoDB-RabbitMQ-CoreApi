using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLTP.Infrastructure.DataModels.Models
{
    [Table("MLTP_USER_DEVICE")]
    public class MltpUserDevice
    {
        [Column("ID")]
        public virtual int Id { get; set; }

        [Column("USER_ID")]
        public virtual int UserId { get; set; }

        [Column("APP_ID")]
        public virtual string AppId { get; set; }

        [Column("PHONE_MODEL")]
        public virtual string PhoneModel { get; set; }

        [Column("PHONE_VERSION")]
        public virtual string PhoneVersion { get; set; }

        [Column("PLATFORM")]
        public virtual string Platform { get; set; }

        [Column("CREATE_DATE")]
        public virtual DateTime CreateDate { get; set; }
    }
}