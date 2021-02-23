using UnityEngine;

namespace Common.Sound.SE
{
    [CreateAssetMenu(fileName = "SeData", menuName = "DataTable/SeData", order = 0)]
    public sealed class SeData : ScriptableObject
    {
        [SerializeField] private AudioClip clip = default;
        [SerializeField] private SeType type = default;

        public AudioClip audioClip => clip;
        public SeType seType => type;
    }
}