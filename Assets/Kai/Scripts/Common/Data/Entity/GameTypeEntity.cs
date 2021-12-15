using Kai.Common.Application;
using Kai.Common.Data.Entity.Interface;

namespace Kai.Common.Data.Entity
{
    public sealed class GameTypeEntity : IGameTypeEntity
    {
        private GameType _gameType;

        public GameTypeEntity()
        {
            _gameType = GameType.None;
        }

        public GameType GetGameType() => _gameType;

        public void SetGameType(GameType gameType) => _gameType = gameType;
    }
}