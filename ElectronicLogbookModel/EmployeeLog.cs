using System;
using System.Collections.Generic;

namespace ElectronicLogbookModel
{
    public class EmployeeLog : Base.Base
    {
        public int EmployeeLogId { get; set; }

        public int EmployeeId { get; set; }

        public int EmployeeNumber { get; set; }

        public int LogTypeId { get; set; }

        public string LogDate { get; set; }

        
    }
}
