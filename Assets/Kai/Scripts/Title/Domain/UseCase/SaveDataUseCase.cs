using Kai.Common.Application;
using Kai.Common.Data.Entity;
using Kai.Common.Domain.Repository.Interface;
using Kai.Title.Domain.UseCase.Interface;

namespace Kai.Title.Domain.UseCase
{
    public sealed class SaveDataUseCase : ISaveLanguageUseCase, ISaveSoundUseCase
    {
        private readonly SaveData _saveData;
        private readonly ISaveDataRepository _saveDataRepository;

        public SaveDataUseCase(ISaveDataRepository saveDataRepository)
        {
            _saveDataRepository = saveDataRepository;
            _saveData = _saveDataRepository.Load();
        }

        public LanguageType language => _saveData.language;

        public void SaveLanguage(LanguageType languageType)
        {
            _saveData.language = languageType;
            _saveDataRepository.Save(_saveData);
        }

        public float bgmVolume => _saveData.bgmVolume;

        public void SaveBgmVolume(float bgmVolumeValue)
        {
            _saveData.bgmVolume = bgmVolumeValue;
            _saveDataRepository.Save(_saveData);
        }

        public float seVolume => _saveData.seVolume;

        public void SaveSeVolume(float seVolumeValue)
        {
            _saveData.seVolume = seVolumeValue;
            _saveDataRepository.Save(_saveData);
        }
    }
}