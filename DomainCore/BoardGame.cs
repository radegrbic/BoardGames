using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore
{
    public class BoardGame
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BoardGameId { get; set; }

        [Required(ErrorMessage = "Please enter a name for the boardgame")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Please give a description for the boardgame")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Please choose a genre for the boardgame")]
        public Genre Genre { get; set; }

        public bool Is18Plus { get; set; }

        [Required(ErrorMessage = "Please set a picture for the boardgame")]
        public byte[] Image { get; set; } = null!;

        [Required(ErrorMessage = "Please choose a gametype for the boardgame")]
        public GameType GameType { get; set; }


    }
}
