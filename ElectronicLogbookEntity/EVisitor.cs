using BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ElectronicLogbookEntity
{
    [Table("Visitor")]
    public class EVisitor : EBase
    {
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }

        public int PersonToVisit { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int VisitorId { get; set; }

        public string Comment { get; set; }
        [StringLength(50)]
        public string CompanyName { get; set; }
        [StringLength(50)]
        public string KindOfId { get; set; }
        [StringLength(50)]
        public string IdNumber { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string MiddleName { get; set; }
        [StringLength(50)]
        public string Purpose { get; set; }
    }
}
