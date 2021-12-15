using Kai.Common.Application;
using Kai.Common.Domain.Model.Interface;
using UniRx;

namespace Kai.Common.Domain.Model
{
    public sealed class GameTypeModel : IGameTypeModel
    {
        private readonly ReactiveProperty<GameType> _gameType;

        public GameTypeModel()
        {
            _gameType = new ReactiveProperty<GameType>(GameType.None);
        }

        public IReadOnlyReactiveProperty<GameType> gameType => _gameType;

        public void SetGameType(GameType type) => _gameType.Value = type;
    }
}