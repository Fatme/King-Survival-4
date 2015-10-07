namespace KingSurvival.Players
{
    using System.Collections.Generic;

    using KingSurvival.Players.Contracts;

    public class PawnPlayer : Player, IPlayer
    {
        public PawnPlayer(string name)
            : base(name)
        {
        }

        public override List<string> Commands
        {
            get { return new List<string>() { "adr", "bdr", "ddr", "cdr", "adl", "bdl", "cdl", "ddl", "undo" }; }
        }
    }
}
