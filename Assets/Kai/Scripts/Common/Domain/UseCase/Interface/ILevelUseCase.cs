namespace Kai.Common.Domain.UseCase.Interface
{
    public interface ILevelUseCase
    {
        int GetLevel();
        void SetLevel(int level);
        void CountUp();
        void ResetLevel();
    }
}