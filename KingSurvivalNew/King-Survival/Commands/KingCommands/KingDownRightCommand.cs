namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class KingDownRightCommand : PlayerCommand, IPlayerCommand
    {
        public KingDownRightCommand(IBoard board)
            : base(board)
        {
        }

        public string Name
        {
            get { return "kdr"; }
        }

        public override int Direction
        {
            get { return 1; }
        }

        public override int FigureIndex
        {
            get { return 0; }
        }
    }
}
