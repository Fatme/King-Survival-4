namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class PawnDDownRightCommand : MoveCommand, IPlayerCommand
    {
        public PawnDDownRightCommand(ICommandContext context)
            : base(context,3,1)
        {
        }

        public override string Name
        {
            get { return "ddr"; }
        }

    }
}
