using Kai.Common.Data.Entity.Interface;
using Kai.Common.Domain.Repository.Interface;
using Kai.Game.Domain.UseCase.Interface;

namespace Kai.Game.Domain.UseCase
{
    public sealed class ClearDataUseCase : IClearDataUseCase
    {
        private readonly ILevelEntity _levelEntity;
        private readonly ISaveDataRepository _saveDataRepository;

        public ClearDataUseCase(ILevelEntity levelEntity, ISaveDataRepository saveDataRepository)
        {
            _levelEntity = levelEntity;
            _saveDataRepository = saveDataRepository;
        }

        public void SaveFreePlayClearData()
        {
            var saveData = _saveDataRepository.Load();

            // クリア済みの場合
            if (saveData.clearData[_levelEntity.GetLevel()])
            {
                return;
            }

            saveData.clearData[_levelEntity.GetLevel()] = true;
            _saveDataRepository.Save(saveData);
        }

        public void SaveScoreAttackData()
        {
            var saveData = _saveDataRepository.Load();

            // クリア済みの場合
            if (saveData.rankData[_levelEntity.GetLevel()])
            {
                return;
            }

            saveData.rankData[_levelEntity.GetLevel()] = true;
            _saveDataRepository.Save(saveData);
        }
    }
}