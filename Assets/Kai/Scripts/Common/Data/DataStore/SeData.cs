using Kai.Common.Application;
using UnityEngine;

namespace Kai.Common.Data.DataStore
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