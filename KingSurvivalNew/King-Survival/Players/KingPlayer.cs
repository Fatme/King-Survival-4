using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvival.Commands;
using KingSurvival.Commands.Contracts;
using KingSurvival.Common;
using KingSurvival.Players.Contracts;

namespace KingSurvival.Players
{
    public class KingPlayer : Player, IPlayer
    {
        public KingPlayer(string name)
            : base(name)
        {
        }

        public override List<string> Commands
        {
            get { return new List<string>() { "kur", "kdl", "kul", "kdr", "undo" }; }
        }
    }
}
