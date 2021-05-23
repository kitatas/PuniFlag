using Kai.Common.Data.Entity;

namespace Kai.Common.Domain.Repository.Interface
{
    public interface ISaveDataRepository
    {
        SaveData Load();
        void Save(SaveData saveData);
    }
}