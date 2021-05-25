using Kai.Common.Application;
using Kai.Common.Data.DataStore;
using Kai.Common.Domain.Repository.Interface;

namespace Kai.Common.Domain.Repository
{
    public sealed class LanguageRepository : ILanguageRepository
    {
        private readonly LanguageTable _languageTable;

        public LanguageRepository(LanguageTable languageTable)
        {
            _languageTable = languageTable;
        }

        public LanguageData Find(LanguageType languageType)
        {
            return _languageTable.languageData
                .Find(x => x.language == languageType);
        }
    }
}