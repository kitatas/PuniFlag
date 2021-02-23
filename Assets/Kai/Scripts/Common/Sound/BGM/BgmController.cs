using System.Collections.Generic;
using Zenject;

namespace Common.Sound.BGM
{
    public sealed class BgmController : BaseAudioSource
    {
        private List<BgmData> _bgmData;

        [Inject]
        private void Construct(BgmTable bgmTable)
        {
            _bgmData = bgmTable.bgmData;
        }

        public void Play(BgmType bgmType, bool isLoop = true)
        {
            var bgmData = _bgmData.Find(data => data.bgmType == bgmType);
            if (bgmData == null)
            {
                return;
            }

            if (bgmData.audioClip == null)
            {
                return;
            }

            if (audioSource.clip == bgmData.audioClip)
            {
                return;
            }

            audioSource.clip = bgmData.audioClip;
            audioSource.loop = isLoop;
            audioSource.Play();
        }

        public void Stop()
        {
            audioSource.Stop();
        }
    }
}