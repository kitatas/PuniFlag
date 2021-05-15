namespace Kai.Common.Data.Entity.Interface
{
    public interface IStepCountEntity
    {
        int GetStepCount();
        void CountUp();
        void ResetStepCount();
    }
}