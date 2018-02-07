using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicLogbookEntity
{
    [Table("Applicant")]
    public class EApplicant : EBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ApplicantID { get; set; }
        [StringLength(50)]
        public string Date { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public string ApplyingFor { get; set; }
        [StringLength(50)]
        public string Designation { get; set; }
        [StringLength(50)]
        public string TypeOfId { get; set; }
        [StringLength(50)]
        public string IdNumber { get; set; }
        [StringLength(50)]
        public string TimeIn { get; set; }
        [StringLength(50)]
        public string TimeOut { get; set; }
        public string Comment { get; set; }
    }
}
