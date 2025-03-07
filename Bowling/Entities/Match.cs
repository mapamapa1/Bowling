using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Entities
{
    public class Match
    {
        [Key]
        public int MatchID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual List<MatchPlayer> MatchPlayers { get; set; }



    }
}
