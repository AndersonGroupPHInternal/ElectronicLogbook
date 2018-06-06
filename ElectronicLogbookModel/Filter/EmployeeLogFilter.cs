using System;

namespace ElectronicLogbookModel.Filter
{
    public class EmployeeLogFilter: EmployeeLog
    {
        public DateTime LogDateFrom { get; set; }
        public DateTime LogDateTo { get; set; }
    }
}
