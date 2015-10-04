namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
using KingSurvival.Commands.Contracts;

    public class KingDownLeftCommand : PlayerCommand, IPlayerCommand
    {
        public KingDownLeftCommand(IBoard board)
            : base(board)
        { 
        }

        public string Name
        {
            get { return "kdl"; }
        }

        public override int Direction
        {
            get { return 2; }
        }

        public override int FigureIndex
        {
            get { return 0; }
        }
    }
}
