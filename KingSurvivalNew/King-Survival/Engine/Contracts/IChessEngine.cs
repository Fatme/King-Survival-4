
namespace KingSurvival.Engine.Contracts
{
   

    using KingSurvival.Players.Contracts;

   public interface IChessEngine
    {
        

        void Initialize();

        void Start();

        bool WinningConditions();

    }
}
