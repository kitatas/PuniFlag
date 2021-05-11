using Common.Application;
using UnityEngine;

namespace Common.Data.DataStore
{
    [CreateAssetMenu(fileName = "BgmData", menuName = "DataTable/BgmData", order = 0)]
    public sealed class BgmData : ScriptableObject
    {
        [SerializeField] private AudioClip clip = default;
        [SerializeField] private BgmType type = default;

        public AudioClip audioClip => clip;
        public BgmType bgmType => type;
    }
}