namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class KingUpRightCommand : PlayerCommand, IPlayerCommand
    {
        public KingUpRightCommand(IBoard board)
            : base(board)
        {
        }

        public string Name
        {
            get { return "kur"; }
        }

        public override int Direction
        {
            get { return 0; }
        }

        public override int FigureIndex
        {
            get { return 0; }
        }
    }
}
