using Kai.Common.Application;
using Kai.Common.Data.Entity;
using Kai.Common.Domain.Repository.Interface;
using UnityEngine;

namespace Kai.Common.Domain.Repository
{
    public sealed class SaveDataRepository : ISaveDataRepository
    {
        private const string SAVE_KEY = "SaveKey";

        private readonly string _defaultData;

        public SaveDataRepository()
        {
            var data = new SaveData
            {
                bgmVolume = 0.5f,
                seVolume = 0.5f,
                language = LanguageType.Japanese,
            };
            _defaultData = JsonUtility.ToJson(data);
        }

        public SaveData Load()
        {
            var data = ES3.Load(SAVE_KEY, defaultValue: _defaultData);
            return JsonUtility.FromJson<SaveData>(data);
        }

        public void Save(SaveData saveData)
        {
            var data = JsonUtility.ToJson(saveData);
            ES3.Save(SAVE_KEY, data);
        }
    }
}