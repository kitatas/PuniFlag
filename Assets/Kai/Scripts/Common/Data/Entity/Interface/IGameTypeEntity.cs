using Kai.Common.Application;

namespace Kai.Common.Data.Entity.Interface
{
    public interface IGameTypeEntity
    {
        GameType GetGameType();
        void SetGameType(GameType gameType);
    }
}