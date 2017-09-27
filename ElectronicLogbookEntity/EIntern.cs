using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicLogbookEntity
{
    [Table("Intern")]
    public class EIntern : EBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
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
        public string Supervisor { get; set; }
        [StringLength(50)]
        public string IdNumber { get; set; }
        [StringLength(50)]
        public string TimeIn { get; set; }
        [StringLength(50)]
        public string TimeOut { get; set; }
    }
}
