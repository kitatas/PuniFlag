using Kai.Common.Data.Entity.Interface;

namespace Kai.Common.Data.Entity
{
    public sealed class StepCountEntity : IStepCountEntity
    {
        private int _stepCount;

        public StepCountEntity()
        {
            _stepCount = 0;
        }

        public int GetStepCount() => _stepCount;

        private void SetStepCount(int value) => _stepCount = value;

        public void CountUp() => SetStepCount(GetStepCount() + 1);

        public void ResetStepCount() => SetStepCount(0);
    }
}