namespace KingSurvival.Commands
{
    using KingSurvival.Commands.Contracts;

    public class KingUpLeftCommand : MoveCommand, IMoveCommand
    {
        public KingUpLeftCommand()
            : base(0, 3)
        {
        }

        public override string Name
        {
            get { return "kul"; }
        }
    }
}
