namespace Kai.Common.Data.Entity.Interface
{
    public interface ILevelEntity
    {
        int GetLevel();
        void LevelUp();
        void ResetLevel();
    }
}