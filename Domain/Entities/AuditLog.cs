using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AuditLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Action { get; set; }
        public string Entity { get; set; }
        
        public string Username { get; set; }
        [ForeignKey("Username")]
        public virtual User User {  get; set; }
    }
}
