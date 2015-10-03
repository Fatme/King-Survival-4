namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class KingDownRightCommand : Command, IPlayerCommand
    {
        public KingDownRightCommand(IBoard board)
            : base(board)
        {
        }

        public string Name
        {
            get { return "kdr"; }
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
