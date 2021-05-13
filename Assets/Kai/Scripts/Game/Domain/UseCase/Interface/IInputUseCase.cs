namespace Game.Domain.UseCase.Interface
{
    public interface IInputUseCase
    {
        bool isMoveLeft { get; }
        bool isMoveRight { get; }
        bool isRotateLeft { get; }
        bool isRotateRight { get; }
        bool isReset { get; }
        bool isBack { get; }
    }
}