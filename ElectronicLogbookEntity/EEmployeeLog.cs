using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicLogbookEntity
{
    [Table("EmployeeLog")]
    public class EEmployeeLog : EBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EmployeeLogId { get; set; }
        public int EmployeeId { get; set; }
        public int EmployeeNumber { get; set; }
        public int LogTypeId { get; set; }
        [StringLength(50)]
        public string LogDate { get; set; }
    }
}
