using Kai.Common.Application;
using UniRx;

namespace Kai.Common.Domain.Model.Interface
{
    public interface IGameTypeModel
    {
        IReadOnlyReactiveProperty<GameType> gameType { get; }
        void SetGameType(GameType type);
    }
}