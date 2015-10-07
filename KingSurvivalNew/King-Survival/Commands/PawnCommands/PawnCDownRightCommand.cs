namespace KingSurvival.Commands.PawnCommands
{
    using KingSurvival.Commands.Contracts;

    public class PawnCDownRightCommand : MoveCommand, IMoveCommand
    {
        public PawnCDownRightCommand()
            : base(2, 1)
        {
        }

        public override string Name
        {
            get { return "cdr"; }
        }
    }
}
