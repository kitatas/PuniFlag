using Game.Data.Container;
using Game.Data.Entity;
using Game.Domain.Model;
using Game.Domain.Repository;
using Game.Domain.UseCase;
using Game.Factory;
using Game.Presentation.Controller;
using Game.Presentation.Presenter;
using Game.Presentation.View;
using Game.Presentation.View.State;
using UnityEngine;
using Zenject;

namespace Game.Installer
{
    public sealed class GameInstaller : MonoInstaller
    {
        [SerializeField] private ButtonController buttonController = default;
        [SerializeField] private StageView stageView = default;
        [SerializeField] private ClearView clearView = default;

        [SerializeField] private InputState inputState = default;
        [SerializeField] private MoveState moveState = default;
        [SerializeField] private ClearState clearState = default;


        public override void InstallBindings()
        {
            #region Container

            Container
                .BindInterfacesTo<PlayerContainer>()
                .AsCached();

            Container
                .BindInterfacesTo<FlagContainer>()
                .AsCached();

            #endregion

            #region Entity

            Container
                .BindInterfacesTo<GameStateEntity>()
                .AsCached();

            #endregion

            #region Model

            Container
                .BindInterfacesTo<GameStateModel>()
                .AsCached();

            #endregion

            #region Repository

            Container
                .BindInterfacesTo<StageRepository>()
                .AsCached();

            #endregion

            #region UseCase

            Container
                .BindInterfacesTo<GameStateUseCase>()
                .AsCached();

            Container
                .Bind<StageDataUseCase>()
                .AsCached()
                .NonLazy();

            Container
                .BindInterfacesTo<StageObjectContainerUseCase>()
                .AsCached();

            Container
                .BindInterfacesTo<InputUseCase>()
                .AsCached();

            #endregion

            #region Controller

            Container
                .Bind<ButtonController>()
                .FromInstance(buttonController)
                .AsCached();

            #endregion

            #region Presenter

            Container
                .Bind<StatePresenter>()
                .AsCached()
                .NonLazy();

            #endregion

            #region View

            Container
                .Bind<InputState>()
                .FromInstance(inputState)
                .AsCached();

            Container
                .Bind<MoveState>()
                .FromInstance(moveState)
                .AsCached();

            Container
                .Bind<ClearState>()
                .FromInstance(clearState)
                .AsCached();

            Container
                .Bind<StageView>()
                .FromInstance(stageView)
                .AsCached();

            Container
                .Bind<ClearView>()
                .FromInstance(clearView)
                .AsCached();

            #endregion

            #region Factory

            Container
                .BindInterfacesTo<StageObjectFactory>()
                .AsCached();

            #endregion
        }
    }
}