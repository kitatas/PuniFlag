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
            saveData.clearData[_levelEntity.GetLevel()] = true;
            _saveDataRepository.Save(saveData);
        }
    }
}