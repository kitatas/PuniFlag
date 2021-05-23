using Kai.Common.Application;
using Kai.Common.Domain.UseCase.Interface;
using Kai.Common.Presentation.Controller;
using Kai.Common.Presentation.Controller.Interface;
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
        private void Construct(BgmController bgmController, SeController seController, ISaveDataUseCase saveDataUseCase)
        {
            bgmSlider
                .OnPointerUpAsObservable()
                .Subscribe(_ =>
                {
                    saveDataUseCase.saveData.bgmVolume = bgmController.GetVolume();
                    saveDataUseCase.Save();
                })
                .AddTo(bgmSlider);

            seSlider
                .OnPointerUpAsObservable()
                .Subscribe(_ =>
                {
                    seController.PlaySe(SeType.Decision);
                    saveDataUseCase.saveData.seVolume = seController.GetVolume();
                    saveDataUseCase.Save();
                })
                .AddTo(seSlider);

            var saveData = saveDataUseCase.saveData;
            bgmController.SetVolume(saveData.bgmVolume);
            seController.SetVolume(saveData.seVolume);
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