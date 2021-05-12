using Game.Domain.Repository;
using Game.Domain.UseCase;
using Game.Factory;
using Game.Player;
using Game.Presentation.View;
using UnityEngine;
using Zenject;

namespace Game.Installer
{
    public sealed class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerController playerController = default;
        [SerializeField] private StageView stageView = default;

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

            #region Domain

            #region Repository

            Container
                .BindInterfacesTo<StageRepository>()
                .AsCached();

            #endregion

            #region UseCase

            Container
                .Bind<StageDataUseCase>()
                .AsCached()
                .NonLazy();

            #endregion

            #endregion

            #region Presentation

            #region View

            Container
                .Bind<StageView>()
                .FromInstance(stageView)
                .AsCached();

            #endregion

            #endregion

            #region Factory

            Container
                .BindInterfacesTo<StageObjectFactory>()
                .AsCached();

            #endregion
        }
    }
}