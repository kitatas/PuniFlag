using Game.Presentation.View;

namespace Game.Data.Container.Interface
{
    public interface IWriteOnlyFlagContainer
    {
        void Add(FlagView flagView);
    }
}