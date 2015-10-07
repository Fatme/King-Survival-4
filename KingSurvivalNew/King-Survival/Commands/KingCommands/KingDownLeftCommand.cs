namespace KingSurvival.Commands.KingCommands
{
    using KingSurvival.Commands.Contracts;

    public class KingDownLeftCommand : MoveCommand, IMoveCommand
    {
        public KingDownLeftCommand()
            : base(0, 2)
        {
        }

        public override string Name
        {
            get { return "kdl"; }
        }
    }
}
