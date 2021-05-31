using System.Collections.Generic;
using Kai.Common.Application;
using Kai.Common.Data.DataStore;
using Kai.Common.Data.Entity;
using Kai.Common.Domain.Repository.Interface;
using UnityEngine;

namespace Kai.Common.Domain.Repository
{
    public sealed class LanguageRepository : ILanguageRepository
    {
        private readonly List<LanguageDataEntity> _dataEntities;

        public LanguageRepository(LanguageTable languageTable)
        {
            _dataEntities = new List<LanguageDataEntity>();
            foreach (var language in languageTable.languageData)
            {
                var data = JsonUtility.FromJson<LanguageDataEntity>(language.ToString());
                _dataEntities.Add(data);
            }
        }

        public LanguageData Find(LanguageType languageType)
        {
            return _dataEntities
                .Find(x => x.type == languageType)
                .data;
        }
    }
}