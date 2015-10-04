namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class PawnCDownRightCommand : MoveCommand, IPlayerCommand
    {
        public PawnCDownRightCommand(ICommandContext context)
            : base(context,2,1)
        {
        }

        public override string Name
        {
            get { return "cdr"; }
        }

    }
}
