namespace KingSurvival.Commands.PawnCommands
{
    using KingSurvival.Commands.Contracts;

    public class PawnBDownLeftCommand : MoveCommand, IMoveCommand
    {
        public PawnBDownLeftCommand()
            : base(1, 2)
        {
        }

        public override string Name
        {
            get { return "bdl"; }
        }
    }
}
