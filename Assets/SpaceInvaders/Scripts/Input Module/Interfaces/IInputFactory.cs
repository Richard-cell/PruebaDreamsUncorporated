namespace SpaceInvaders
{
    public interface IInputFactory
    {
        IInputStrategy GetInputStrategyByType(InputType inputType);
    }
}
