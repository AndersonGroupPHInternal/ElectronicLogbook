using System;
using BaseModel;

namespace ElectronicLogbookModel
{
    public class Visitor : Base
    {
        public DateTime? TimeIn { get; set; }
        public Nullable<DateTime> TimeOut { get; set; }

        public int PersonToVisit { get; set; }
        public int VisitorId { get; set; }

        public string Comment { get; set; }
        public string CompanyName { get; set; }
        public string KindOfId { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Purpose { get; set; }
    }
}
