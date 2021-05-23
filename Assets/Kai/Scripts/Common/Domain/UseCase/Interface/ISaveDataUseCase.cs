using Kai.Common.Data.Entity;

namespace Kai.Common.Domain.UseCase.Interface
{
    public interface ISaveDataUseCase
    {
        SaveData saveData { get; }
        void Save();
    }
}