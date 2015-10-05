using KingSurvival.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvival.Commands;
using KingSurvival.Commands.Contracts;
using KingSurvival.Common;

namespace KingSurvival.Players
{
    public class PawnPlayer:Player,IPlayer
    {
        public PawnPlayer(string name):base(name)
        {
        }

     
        public override List<string> Commands
        {
            get { return new List<string>() { "adr", "bdr", "ddr", "cdr","adl","bdl","cdl","ddl", "undo" }; }
        }
    }
}
