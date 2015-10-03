namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class PawnCDownRightCommand : Command, IPlayerCommand
    {
        public PawnCDownRightCommand(IBoard board)
            : base(board)
        {
        }

        public string Name
        {
            get { return "cdr"; }
        }

        public int Direction
        {
            get { return 1; }
        }

        public int FigureIndex
        {
            get { return 2; }
        }
    }
}
