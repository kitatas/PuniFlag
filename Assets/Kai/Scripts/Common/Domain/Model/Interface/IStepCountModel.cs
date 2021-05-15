using UniRx;

namespace Kai.Common.Domain.Model.Interface
{
    public interface IStepCountModel
    {
        IReadOnlyReactiveProperty<int> stepCount { get; }
        void SetStepCount(int value);
    }
}