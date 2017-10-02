using System;
using System.Collections.Generic;

namespace ElectronicLogbookModel
{
    public class Applicant : Base.Base
    {
        public int ApplicantID { get; set; }

        public string Date { get; set; }

        public string Name { get; set; }

        public string ApplyingFor { get; set; }

        public string Designation { get; set; }

        public string TypeOfId { get; set; }

        public string IdNumber { get; set; }

        public string TimeIn { get; set; }

        public string TimeOut { get; set; }

        public string Comment { get; set; }
    }
}
