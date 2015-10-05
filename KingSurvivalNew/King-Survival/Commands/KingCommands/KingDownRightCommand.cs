namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class KingDownRightCommand : MoveCommand, IPlayerCommand
    {
        public KingDownRightCommand()
            : base(0,1)
        {
        }

        public override string Name
        {
            get { return "kdr"; }
        }

    }
}
