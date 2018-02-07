using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;


namespace ElectronicLogbookEntity
{
    [Table("InternHistory")]
    public class EInternHistory : EBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int InternHistoryID { get; set; }
        [ForeignKey("Intern")]
        public int InternID { get; set; }
        [StringLength(50)]
        public string Date { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string School { get; set; }
        [StringLength(50)]
        public string Department { get; set; }
        [StringLength(50)]
        public string IdNumber { get; set; }
        [StringLength(50)]
        public string TimeIn { get; set; }
        [StringLength(50)]
        public string TimeOut { get; set; }
        public virtual EIntern Intern { get; set; }
    }
}
