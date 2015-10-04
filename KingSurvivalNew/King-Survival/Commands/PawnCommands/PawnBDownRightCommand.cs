namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class PawnBDownRightCommand : PlayerCommand, IPlayerCommand
    {
        public PawnBDownRightCommand(IBoard board)
            : base(board)
        {
        }

        public string Name
        {
            get { return "bdr"; }
        }

        public override int Direction
        {
            get { return 1; }
        }

        public override int FigureIndex
        {
            get { return 1; }
        }
    }
}
