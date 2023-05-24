using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pointeuse.Models
{
    public class Eleve
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string EMail { get; set; }
        public string Phone{ get; set; }




        [ForeignKey("Promotion")]
        public int IdPromotion { get; set; }
        public Promotion Promotion { get; set; }

        [ForeignKey("Groupe")]
        public int IdGroupe { get; set; }
        public Groupe Groupe { get; set; }


    }
}
