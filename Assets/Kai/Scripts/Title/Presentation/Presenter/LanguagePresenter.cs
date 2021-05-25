using Kai.Title.Domain.UseCase.Interface;
using Kai.Title.Presentation.View;
using UniRx;

namespace Kai.Title.Presentation.Presenter
{
    public sealed class LanguagePresenter
    {
        public LanguagePresenter(IReadOnlyLanguageUseCase languageUseCase, LanguageView languageView)
        {
            languageUseCase.language
                .Subscribe(x =>
                {
                    var data = languageUseCase.GetLanguageData(x);
                    languageView.Show(data);
                })
                .AddTo(languageView);
        }
    }
}