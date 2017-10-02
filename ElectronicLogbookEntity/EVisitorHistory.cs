using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ElectronicLogbookEntity
{
    [Table("VisitorHistory")]
    public class EVisitorHistory : EBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int VisitorHistoryID { get; set; }
        [ForeignKey("Visitor")]
        public int VisitorID { get; set; }
        [StringLength(50)]
        public string Date { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Purpose { get; set; }
        [StringLength(50)]
        public string TimeIn { get; set; }
        [StringLength(50)]
        public string TimeOut { get; set; }
        public virtual EVisitor Visitor { get; set; }
    }
}
