using Game.Player;
using Game.Stage;
using UnityEngine;
using Zenject;

namespace Game.Installer
{
    public sealed class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerController playerController = default;
        [SerializeField] private StageRotator stageRotator = default;

        public override void InstallBindings()
        {
            #region Player

            Container
                .Bind<PlayerController>()
                .FromInstance(playerController)
                .AsCached();

            Container
                .Bind<PlayerInput>()
                .AsCached();

            #endregion

            #region Stage

            Container
                .Bind<StageRotator>()
                .FromInstance(stageRotator)
                .AsCached();

            #endregion
        }
    }
}