namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class PawnBDownRightCommand : Command, IPlayerCommand
    {
        public PawnBDownRightCommand(IBoard board)
            : base(board)
        {
        }

        public string Name
        {
            get { return "bdr"; }
        }

        public int Direction
        {
            get { return 1; }
        }

        public int FigureIndex
        {
            get { return 1; }
        }
    }
}
