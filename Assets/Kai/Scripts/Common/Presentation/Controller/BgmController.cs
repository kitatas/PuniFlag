using Common.Application;
using Common.Domain.UseCase.Interface;
using Zenject;

namespace Common.Presentation.Controller
{
    public sealed class BgmController : BaseAudioSource
    {
        private IBgmUseCase _bgmUseCase;

        [Inject]
        private void Construct(IBgmUseCase bgmUseCase)
        {
            _bgmUseCase = bgmUseCase;
        }

        public void Play(BgmType bgmType, bool isLoop = true)
        {
            var clip = _bgmUseCase.GetBgmClip(bgmType);

            if (clip == null || audioSource.clip == clip)
            {
                return;
            }

            audioSource.clip = clip;
            audioSource.loop = isLoop;
            audioSource.Play();
        }

        public void Stop()
        {
            audioSource.Stop();
        }
    }
}