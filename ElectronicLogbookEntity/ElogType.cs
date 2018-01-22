using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicLogbookEntity
{
    [Table("LogType")]
    public class ELogType : EBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LogTypeId { get; set; }
        public string Name { get; set; }
    }
}
