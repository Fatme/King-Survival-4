namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
using KingSurvival.Commands.Contracts;

    public class KingDownLeftCommand : Command, IPlayerCommand
    {
        public KingDownLeftCommand(IBoard board)
            : base(board)
        { 
        }

        public string Name
        {
            get { return "kdl"; }
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
