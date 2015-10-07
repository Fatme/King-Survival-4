namespace KingSurvival.Commands.PawnCommands
{
    using KingSurvival.Commands.Contracts;

    public class PawnCDownLeftCommand : MoveCommand, IMoveCommand
    {
        public PawnCDownLeftCommand()
            : base(2, 2)
        {
        }

        public override string Name
        {
            get { return "cdl"; }
        }
    }
}
