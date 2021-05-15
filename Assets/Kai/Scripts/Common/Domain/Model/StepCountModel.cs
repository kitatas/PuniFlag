using Common.Domain.Model.Interface;
using UniRx;

namespace Common.Domain.Model
{
    public sealed class StepCountModel : IStepCountModel
    {
        private readonly ReactiveProperty<int> _stepCount;

        public StepCountModel()
        {
            _stepCount = new ReactiveProperty<int>(0);
        }

        public IReadOnlyReactiveProperty<int> stepCount => _stepCount;

        public void SetStepCount(int value) => _stepCount.Value = value;
    }
}