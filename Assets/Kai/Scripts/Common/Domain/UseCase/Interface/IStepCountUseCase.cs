namespace Kai.Common.Domain.UseCase.Interface
{
    public interface IStepCountUseCase
    {
        int GetStepCount();
        void CountUp();
        void ResetStepCount();
    }
}