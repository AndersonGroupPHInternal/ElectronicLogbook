using System.Collections.Generic;

namespace ElectronicLogbookModel
{
    public class Visitor : Base.Base
    {
        public int VisitorID { get; set; }

        public string Date { get; set; }

        public string Name { get; set; }

        public string CompanyName { get; set; }

        public string Purpose { get; set; }

        public string PersonToVisit { get; set; }

        public string IdNumber { get; set; }

        public string TimeIn { get; set; }

        public string TimeOut { get; set; }
    }
}
