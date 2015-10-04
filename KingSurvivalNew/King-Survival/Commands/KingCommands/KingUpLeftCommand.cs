namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class KingUpLeftCommand : PlayerCommand, IPlayerCommand
    {
        public KingUpLeftCommand(IBoard board)
            : base(board)
        {
        }

        public string Name
        {
            get { return "kul"; }
        }

        public override int Direction
        {
            get { return 3; }
        }

        public override int FigureIndex
        {
            get { return 0; }
        }
    }
}
