namespace Common.Domain.UseCase.Interface
{
    public interface ILevelUseCase
    {
        int GetLevel();
        void CountUp();
        void ResetLevel();
    }
}