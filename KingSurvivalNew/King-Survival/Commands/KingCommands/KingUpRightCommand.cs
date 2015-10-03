namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class KingUpRightCommand : Command, IPlayerCommand
    {
        public KingUpRightCommand(IBoard board)
            : base(board)
        {
        }

        public string Name
        {
            get { return "kur"; }
        }

        public int Direction
        {
            get { return 0; }
        }

        public int FigureIndex
        {
            get { return 0; }
        }
    }
}
