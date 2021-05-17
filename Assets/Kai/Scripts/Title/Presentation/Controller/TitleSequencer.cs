using Kai.Common.Application;
using Kai.Common.Domain.UseCase.Interface;
using Kai.Common.Extension;
using UnityEngine;
using Zenject;

namespace Kai.Title.Presentation.Controller
{
    public sealed class TitleSequencer : MonoBehaviour
    {
        [Inject]
        private void Construct(IStepCountUseCase stepCountUseCase)
        {
            var delayTime = CommonViewConfig.LOAD_INTERVAL + CommonViewConfig.FADE_TIME;

            this.DelayAction(delayTime, () =>
            {
                // 
                stepCountUseCase.ResetStepCount();
            });
        }
    }
}