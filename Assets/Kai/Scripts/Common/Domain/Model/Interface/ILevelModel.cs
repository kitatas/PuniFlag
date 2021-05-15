using UniRx;

namespace Common.Domain.Model.Interface
{
    public interface ILevelModel
    {
        IReadOnlyReactiveProperty<int> level { get; }
        void SetLevel(int value);
    }
}