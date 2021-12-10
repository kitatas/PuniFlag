using Kai.Title.Domain.Repository;
using Kai.Title.Domain.UseCase;
using Kai.Title.Presentation.Presenter;
using Kai.Title.Presentation.View;
using UnityEngine;
using Zenject;

namespace Kai.Title.Installer
{
    public sealed class TitleInstaller : MonoInstaller
    {
        [SerializeField] private LanguageView languageView = default;

        public override void InstallBindings()
        {
            #region Repository

            Container
                .BindInterfacesTo<StageDataRepository>()
                .AsCached();

            #endregion
            
            #region UseCase

            Container
                .BindInterfacesTo<LanguageUseCase>()
                .AsCached();

            Container
                .BindInterfacesTo<SaveDataUseCase>()
                .AsCached();

            Container
                .BindInterfacesTo<StageDataUseCase>()
                .AsCached();

            #endregion

            #region Presenter

            Container
                .Bind<LanguagePresenter>()
                .AsCached()
                .NonLazy();

            #endregion

            #region View

            Container
                .Bind<LanguageView>()
                .FromInstance(languageView)
                .AsCached();

            #endregion
        }
    }
}