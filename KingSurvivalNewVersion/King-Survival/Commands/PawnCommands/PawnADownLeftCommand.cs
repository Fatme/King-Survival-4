namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class PawnADownLeftCommand : MoveCommand, IPlayerCommand
    {
        public PawnADownLeftCommand(ICommandContext context)
            : base(context,0,2)
        {
        }

        public override string Name
        {
            get { return "adl"; }
        }

    }
}
