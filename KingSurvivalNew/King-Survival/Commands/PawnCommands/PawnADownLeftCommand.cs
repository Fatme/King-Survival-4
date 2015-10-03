namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class PawnADownLeftCommand : Command, IPlayerCommand
    {
        public PawnADownLeftCommand(IBoard board)
            : base(board)
        {
        }

        public string Name
        {
            get { return "adl"; }
        }

        public int Direction
        {
            get { return 2; }
        }

        public int FigureIndex
        {
            get { return 0; }
        }
    }
}
