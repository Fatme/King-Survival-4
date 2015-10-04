namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class KingDownRightCommand : MoveCommand, IPlayerCommand
    {
        public KingDownRightCommand(ICommandContext context)
            : base(context,0,1)
        {
        }

        public override string Name
        {
            get { return "kdr"; }
        }

    }
}
