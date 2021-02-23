using Game.Player;
using Game.Stage;
using UnityEngine;
using Zenject;

namespace Game.Installer
{
    public sealed class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerController playerController = default;

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


            #endregion
        }
    }
}