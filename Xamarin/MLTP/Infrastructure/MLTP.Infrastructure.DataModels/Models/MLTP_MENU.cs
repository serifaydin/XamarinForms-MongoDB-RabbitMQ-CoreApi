using System.ComponentModel.DataAnnotations.Schema;

namespace MLTP.Infrastructure.DataModels.Models
{
    [Table("MLTP_MENU")]
    public class MltpMenu
    {
        [Column("ID")]
        public virtual int Id { get; set; }

        [Column("DISPLAY_NAME")]
        public virtual string DisplayName { get; set; }

        [Column("PARENT_MENU_ID")]
        public virtual int ParentMenuId { get; set; }

        [Column("ICON")]
        public virtual string Icon { get; set; }

        [Column("PAGENAME")]
        public virtual string PageName { get; set; }

        [Column("RECORD_STATUS_ID")]
        public virtual int RecordStatusId { get; set; }

        [Column("PAGE_REDIRECT")]
        public virtual string PageRedirect { get; set; }
    }
}