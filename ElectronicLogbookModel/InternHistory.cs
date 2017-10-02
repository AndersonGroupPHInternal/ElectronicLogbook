using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLogbookModel
{
    public class InternHistory : Base.Base
    {
        public int InternHistoryID { get; set; }

        public int InternID { get; set; }

        public string Date { get; set; }

        public string Name { get; set; }

        public string School { get; set; }

        public string Department { get; set; }

        public string IdNumber { get; set; }

        public string TimeIn { get; set; }

        public string TimeOut { get; set; }

        public Intern Intern { get; set; }
    }
}
