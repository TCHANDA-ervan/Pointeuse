using System.ComponentModel.DataAnnotations;

namespace Pointeuse.Models
{
    public class Promotion
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Niveau { get; set; }

        public int Annee { get; set; }
    }
}
