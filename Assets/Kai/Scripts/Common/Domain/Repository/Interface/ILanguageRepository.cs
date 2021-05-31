using Kai.Common.Application;
using Kai.Common.Data.Entity;

namespace Kai.Common.Domain.Repository.Interface
{
    public interface ILanguageRepository
    {
        LanguageData Find(LanguageType languageType);
    }
}