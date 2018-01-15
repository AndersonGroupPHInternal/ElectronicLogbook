using System;
using BaseModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace ElectronicLogbookModel
{
    public class EmployeeLog : Base
    {
        public bool SuccesLogin { get; set; }

        public DateTime LogDate { get; set; }

        public int EmployeeLogId { get; set; }
        public int EmployeeId { get; set; }
        public int LogTypeId { get; set; }

        [Required, Display(Name = "Employee Number"), StringLength(100)]
        public string EmployeeNumber { get; set; }
        public string EmployeeImage { get; set; }
        public string EmployeeImageBase64
        {
            get
            {
                if (!string.IsNullOrEmpty(EmployeeImage))
                    return Convert.ToBase64String(File.ReadAllBytes(EmployeeImage + ".jpg"));

                return string.Empty;
            }
        }
        public string LogName { get; set; }
        [Required, Display(Name = "Pin"), DataType(DataType.Password), StringLength(100, MinimumLength = 4)]
        public string Pin { get; set; }

        public LogType LogType { get; set; }
    }
}
