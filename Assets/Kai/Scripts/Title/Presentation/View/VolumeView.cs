using Kai.Common.Application;
using Kai.Common.Presentation.Controller;
using Kai.Common.Presentation.Controller.Interface;
using Kai.Title.Domain.UseCase.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Kai.Title.Presentation.View
{
    public sealed class VolumeView : MonoBehaviour
    {
        [SerializeField] private Slider bgmSlider = default;
        [SerializeField] private Slider seSlider = default;

        [Inject]
        private void Construct(BgmController bgmController, SeController seController,
            ISaveSoundUseCase saveSoundUseCase)
        {
            bgmSlider
                .OnPointerUpAsObservable()
                .Subscribe(_ =>
                {
                    saveSoundUseCase.SaveBgmVolume(bgmController.GetVolume());
                })
                .AddTo(bgmSlider);

            seSlider
                .OnPointerUpAsObservable()
                .Subscribe(_ =>
                {
                    seController.PlaySe(SeType.Decision);
                    saveSoundUseCase.SaveSeVolume(seController.GetVolume());
                })
                .AddTo(seSlider);

            bgmController.SetVolume(saveSoundUseCase.bgmVolume);
            seController.SetVolume(saveSoundUseCase.seVolume);
            SetSliderVolume(bgmController, seController);

            UpdateVolume(bgmController, seController);
        }

        private void SetSliderVolume(IVolumeUseCase bgm, IVolumeUseCase se)
        {
            bgmSlider.value = bgm.GetVolume();
            seSlider.value = se.GetVolume();
        }

        private void UpdateVolume(IVolumeUseCase bgm, IVolumeUseCase se)
        {
            bgmSlider
                .OnValueChangedAsObservable()
                .Subscribe(bgm.SetVolume)
                .AddTo(bgmSlider);

            seSlider
                .OnValueChangedAsObservable()
                .Subscribe(se.SetVolume)
                .AddTo(seSlider);
        }
    }
}