using Kai.Common.Data.Entity;
using Kai.Common.Domain.Repository.Interface;
using Kai.Common.Domain.UseCase.Interface;

namespace Kai.Common.Domain.UseCase
{
    public sealed class SaveDataUseCase : ISaveDataUseCase
    {
        private readonly SaveData _saveData;
        private readonly ISaveDataRepository _saveDataRepository;

        public SaveDataUseCase(ISaveDataRepository saveDataRepository)
        {
            _saveDataRepository = saveDataRepository;
            _saveData = _saveDataRepository.Load();
        }

        public SaveData saveData => _saveData;

        public void Save()
        {
            _saveDataRepository.Save(saveData);
        }
    }
}