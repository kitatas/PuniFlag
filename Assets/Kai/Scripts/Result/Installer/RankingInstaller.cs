using Kai.Result.Domain.UseCase;
using Kai.Result.Presentation.Presenter;
using Kai.Result.Presentation.View;
using UnityEngine;
using Zenject;

namespace Kai.Result.Installer
{
    public sealed class RankingInstaller : MonoInstaller
    {
        [SerializeField] private RankingScreenView rankingScreenView = default;

        public override void InstallBindings()
        {
            #region UseCase

            Container
                .BindInterfacesTo<RankingScreenUseCase>()
                .AsCached();

            #endregion

            #region Presenter

            Container
                .Bind<RankingScreenPresenter>()
                .AsCached()
                .NonLazy();

            #endregion

            #region View

            Container
                .Bind<RankingScreenView>()
                .FromInstance(rankingScreenView)
                .AsCached();

            #endregion
        }
    }
}