using System.Collections.Generic;

namespace ElectronicLogbookModel
{
    public class Intern : Base.Base
    {
        public int InternID { get; set; }

        public string Date { get; set; }

        public string Name { get; set; }

        public string School { get; set; }

        public string Department { get; set; }

        public string Supervisor { get; set; }

        public string IdNumber { get; set; }

        public string TimeIn { get; set; }

        public string TimeOut { get; set; }
    }
}
