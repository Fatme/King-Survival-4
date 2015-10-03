namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class PawnADownRightCommand : Command, IPlayerCommand
    {
        public PawnADownRightCommand(IBoard board)
            : base(board)
        {
        }

        public string Name
        {
            get { return "adr"; }
        }

        public int Direction
        {
            get { return 1; }
        }

        public int FigureIndex
        {
            get { return 0; }
        }
    }
}
