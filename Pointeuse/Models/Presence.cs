using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pointeuse.Models
{
    public class Presence
    {

        [Key]
        public int Id { get; set; }
        public string Statut { get; set; }
        public string HeurePresence { get; set; }



        [ForeignKey("Eleve")]
        public int IdEleve { get; set; }
        public Eleve Eleve { get; set; }    

        
    }
}
