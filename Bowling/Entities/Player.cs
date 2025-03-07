using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Entities
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        public virtual List<MatchPlayer> MatchPlayers { get; set; }

        public Player(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }
        public Player()
        {
                
        }


    }
}
