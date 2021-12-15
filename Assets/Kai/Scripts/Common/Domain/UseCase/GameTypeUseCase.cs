using Kai.Common.Application;
using Kai.Common.Data.Entity.Interface;
using Kai.Common.Domain.Model.Interface;
using Kai.Common.Domain.UseCase.Interface;

namespace Kai.Common.Domain.UseCase
{
    public sealed class GameTypeUseCase : IGameTypeUseCase
    {
        private readonly IGameTypeEntity _gameTypeEntity;
        private readonly IGameTypeModel _gameTypeModel;

        public GameTypeUseCase(IGameTypeEntity gameTypeEntity, IGameTypeModel gameTypeModel)
        {
            _gameTypeEntity = gameTypeEntity;
            _gameTypeModel = gameTypeModel;
        }

        public void SetGameType(GameType gameType)
        {
            _gameTypeEntity.SetGameType(gameType);
            _gameTypeModel.SetGameType(_gameTypeEntity.GetGameType());
        }
    }
}