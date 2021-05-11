using Common.Application;
using Common.Presentation.Controller;
using Common.Presentation.Controller.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Title.View
{
    public sealed class VolumeView : MonoBehaviour
    {
        [SerializeField] private Slider bgmSlider = default;
        [SerializeField] private Slider seSlider = default;

        [Inject]
        private void Construct(BgmController bgmController, SeController seController)
        {
            seSlider
                .OnPointerUpAsObservable()
                .Subscribe(_ => seController.PlaySe(SeType.Decision))
                .AddTo(seSlider);

            SetVolume(bgmController, seController);

            UpdateVolume(bgmController, seController);
        }

        private void SetVolume(IVolumeUseCase bgm, IVolumeUseCase se)
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