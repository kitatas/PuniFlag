using UnityEngine;
using Zenject;

namespace Common.Sound.BGM
{
    public sealed class BgmPlayer : MonoBehaviour
    {
        [SerializeField] private BgmType bgmType = default;

        [Inject]
        private void Construct(BgmController bgmController)
        {
            bgmController.Play(bgmType);
        }
    }
}