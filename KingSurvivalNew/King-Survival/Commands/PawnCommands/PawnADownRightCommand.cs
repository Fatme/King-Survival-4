namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class PawnADownRightCommand : PlayerCommand, IPlayerCommand
    {
        public PawnADownRightCommand(IBoard board)
            : base(board)
        {
        }

        public string Name
        {
            get { return "adr"; }
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
