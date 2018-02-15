using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ElectronicLogbookEntity
{
    [Table("Visitor")]
    public class EVisitor : EBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int VisitorID { get; set; }
        [StringLength(50)]
        public string Date { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string CompanyName { get; set; }
        [StringLength(50)]
        public string Purpose { get; set; }
        public int PersonToVisit { get; set; }
        [StringLength(50)]
        public string Designation { get; set; }
        [StringLength(50)]
        public string IdNumber { get; set; }
        [StringLength(50)]
        public string KindOfId { get; set; }
        [StringLength(50)]
        public string TimeIn { get; set; }
        [StringLength(50)]
        public string TimeOut { get; set; }
        public string Comment { get; set; }
    }
}
