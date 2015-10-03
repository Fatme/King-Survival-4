namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class KingUpLeftCommand : Command, IPlayerCommand
    {
        public KingUpLeftCommand(IBoard board)
            : base(board)
        {
        }

        public string Name
        {
            get { return "kul"; }
        }

        public int Direction
        {
            get { return 3; }
        }

        public int FigureIndex
        {
            get { return 0; }
        }
    }
}
