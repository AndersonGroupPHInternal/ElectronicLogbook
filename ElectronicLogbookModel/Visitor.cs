using System;
using BaseModel;

namespace ElectronicLogbookModel
{
    public class Visitor : Base
    {
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }

        public string EmployeeIdToVisit { get; set; }
        public int VisitorId { get; set; }

        public string Comment { get; set; }
        public string CompanyName { get; set; }
        public string KindOfId { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Purpose { get; set; }
        public string TimeInString => TimeIn.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ','T');
        public string TimeOutString => TimeOut?.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T') ?? string.Empty;
    }
}
