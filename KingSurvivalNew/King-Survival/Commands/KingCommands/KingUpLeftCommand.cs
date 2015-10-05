namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class KingUpLeftCommand : MoveCommand, IPlayerCommand
    {
        public KingUpLeftCommand()
            : base(0,3)
        {
        }

        public  override string Name
        {
            get { return "kul"; }
        }

    }
}
