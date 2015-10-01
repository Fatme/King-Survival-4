namespace KingSurvival.Figures.Contracts
{
    using KingSurvival.Common;

    //TODO:Maybe later do it the figure IMoveable not the player
    interface IMoveable
    {
        Move Move(string command);
    }
}
