namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class PawnDDownRightCommand : PlayerCommand, IPlayerCommand
    {
        public PawnDDownRightCommand(IBoard board)
            : base(board)
        {
        }

        public string Name
        {
            get { return "ddr"; }
        }

        public override int Direction
        {
            get { return 1; }
        }

        public override int FigureIndex
        {
            get { return 3; }
        }
    }
}
