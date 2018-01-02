using BaseEntity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicLogbookEntity
{
    [Table("EmployeeLog")]
    public class EEmployeeLog : EBase
    {
        public DateTime LogDate { get; set; }
        
        public int EmployeeId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EmployeeLogId { get; set; }
        [ForeignKey("LogType")]
        public int LogTypeId { get; set; }

        public string EmployeeNumber { get; set; }
        public ELogType LogType { get; set; }
    }
}
