using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore
{
    public class BoardGameNight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BoardGameNightId { get; set; }
        [Required(ErrorMessage = "Please select the organisor for the boardgamenight")]
        public Organisor Organisor { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int MaximumPlayers { get; set; }
        public DateTime StartTime { get; set; }
        public ICollection<BoardGame> BoardGames { get; set; } = null!;
        public ICollection<Food> AvailableFoods { get; set; } = null!;
    }
}
