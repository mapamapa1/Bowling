using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Entities
{
    public class MatchPlayer
    {
        public int MatchID { get; set; }
        public int PlayerID { get; set; } 
        public int Score { get; set; }

        [ForeignKey("MatchID")]
        public virtual Match Match { get; set; }

        [ForeignKey("PlayerID")]
        public virtual Player Player { get; set; }

    }
}
