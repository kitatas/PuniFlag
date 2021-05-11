using System;
using System.Threading;
using Common.Application;
using Common.Domain.UseCase.Interface;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Common.Presentation.Controller
{
    public sealed class SeController : BaseAudioSource
    {
        private ISeUseCase _seUseCase;

        [Inject]
        private void Construct(ISeUseCase seUseCase)
        {
            _seUseCase = seUseCase;
        }

        public void PlaySe(SeType seType)
        {
            var clip = _seUseCase.GetSeClip(seType);
            if (clip == null)
            {
                return;
            }

            audioSource.PlayOneShot(clip);
        }

        public async UniTaskVoid DelayPlaySeAsync(SeType seType, float delayTime, CancellationToken token)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(delayTime), cancellationToken: token);

            PlaySe(seType);
        }

        public void PlaySe(ButtonType buttonType)
        {
            var clip = _seUseCase.GetSeClip(buttonType);
            if (clip == null)
            {
                return;
            }

            audioSource.PlayOneShot(clip);
        }
    }
}