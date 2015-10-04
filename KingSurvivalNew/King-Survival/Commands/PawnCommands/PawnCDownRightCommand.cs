namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class PawnCDownRightCommand : PlayerCommand, IPlayerCommand
    {
        public PawnCDownRightCommand(IBoard board)
            : base(board)
        {
        }

        public string Name
        {
            get { return "cdr"; }
        }

        public override int Direction
        {
            get { return 1; }
        }

        public override int FigureIndex
        {
            get { return 2; }
        }
    }
}
