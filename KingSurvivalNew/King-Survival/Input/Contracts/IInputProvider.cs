namespace KingSurvival.Input.Contracts
{
   public interface IInputProvider
   {
       string GetPlayerName { get; }

       string GetCommandName { get;  }

       void PrintPlayerNameForNextMove(string playerName);
   }
}
