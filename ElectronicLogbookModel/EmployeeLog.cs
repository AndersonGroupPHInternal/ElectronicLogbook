using BaseModel;
using System;

namespace ElectronicLogbookModel
{
    public class EmployeeLog : Base
    {
        public bool SuccesLogin { get; set; }

        public DateTime LogDate { get; set; }

        public int EmployeeLogId { get; set; }
        public int EmployeeId { get; set; }
        public int LogTypeId { get; set; }

        public string EmployeeNumber { get; set; }
        public string EmployeeImageBase64 { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Pin { get; set; }

        public LogType LogType { get; set; }
    }
}
