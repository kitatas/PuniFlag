using UniRx;

namespace Game.StepCount
{
    public sealed class StepCountModel
    {
        private readonly ReactiveProperty<int> _stepCount;

        public StepCountModel()
        {
            _stepCount = new ReactiveProperty<int>(0);
        }

        public IReadOnlyReactiveProperty<int> stepCount => _stepCount;

        private void SetStepCount(int count) => _stepCount.Value = count;

        public void ResetStepCount() => SetStepCount(0);

        public void CountUp() => SetStepCount(_stepCount.Value + 1);

        public int GetStepCount() => stepCount.Value;
    }
}