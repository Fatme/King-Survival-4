namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class KingUpRightCommand : MoveCommand, IPlayerCommand
    {
        public KingUpRightCommand()
            : base(0,0)
        {
        }

        public override string Name
        {
            get { return "kur"; }
        }

    }
}
