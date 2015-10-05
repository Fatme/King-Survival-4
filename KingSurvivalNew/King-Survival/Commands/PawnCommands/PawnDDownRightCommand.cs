namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class PawnDDownRightCommand : MoveCommand, IPlayerCommand
    {
        public PawnDDownRightCommand()
            : base(3,1)
        {
        }

        public override string Name
        {
            get { return "ddr"; }
        }

    }
}
