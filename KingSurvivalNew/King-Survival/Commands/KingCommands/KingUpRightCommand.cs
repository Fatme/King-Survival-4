namespace KingSurvival.Commands.KingCommands
{
    using KingSurvival.Commands.Contracts;

    public class KingUpRightCommand : MoveCommand, IMoveCommand
    {
        public KingUpRightCommand()
            : base(0, 0)
        {
        }

        public override string Name
        {
            get { return "kur"; }
        }
    }
}
