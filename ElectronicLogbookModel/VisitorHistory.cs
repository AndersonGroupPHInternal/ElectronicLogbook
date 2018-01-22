using BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLogbookModel
{
    public class VisitorHistory : Base
    {
        public int VisitorHistoryID { get; set; }
        public int VisitorID { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public Visitor Visitor { get; set; }
    }
}
