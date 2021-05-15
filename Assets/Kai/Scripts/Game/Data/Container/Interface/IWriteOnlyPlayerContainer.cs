using Game.Presentation.View;

namespace Game.Data.Container.Interface
{
    public interface IWriteOnlyPlayerContainer
    {
        void Add(PlayerView playerView);
    }
}