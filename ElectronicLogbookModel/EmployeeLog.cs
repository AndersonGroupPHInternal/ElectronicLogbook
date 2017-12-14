using System;
using BaseModel;
using System.Collections.Generic;

namespace ElectronicLogbookModel
{
    public class EmployeeLog : Base
    {
        public DateTime LogDate { get; set; }

        public int EmployeeLogId { get; set; }
        public int EmployeeId { get; set; }
        public int LogTypeId { get; set; }

        public string EmployeeNumber { get; set; }

        public LogType LogType { get; set; }
    }
}
