using System;
using BaseModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectronicLogbookModel
{
    public class EmployeeLog : Base
    {
        public DateTime LogDate { get; set; }

        public int EmployeeLogId { get; set; }
        public int EmployeeId { get; set; }
        public int LogTypeId { get; set; }
        public string LogName { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Employee Number")]
        public string EmployeeNumber { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Pin")]
        public string Pin { get; set; }

        public LogType LogType { get; set; }
    }
}
