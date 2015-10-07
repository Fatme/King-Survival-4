namespace KingSurvival.Commands
{
    using KingSurvival.Commands.Contracts;

    public class KingDownRightCommand : MoveCommand, IMoveCommand
    {
        public KingDownRightCommand()
            : base(0, 1)
        {
        }

        public override string Name
        {
            get { return "kdr"; }
        }
    }
}
