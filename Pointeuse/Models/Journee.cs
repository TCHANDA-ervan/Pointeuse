using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pointeuse.Models
{
    public class Journee
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateMatin { get; set; }
        public DateTime DateSoir { get; set; }



    }
}
