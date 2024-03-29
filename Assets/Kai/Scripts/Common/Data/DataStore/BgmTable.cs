using System.Collections.Generic;
using UnityEngine;

namespace Kai.Common.Data.DataStore
{
    [CreateAssetMenu(fileName = "BgmTable", menuName = "DataTable/BgmTable", order = 0)]
    public sealed class BgmTable : ScriptableObject
    {
        [SerializeField] private List<BgmData> data = default;

        public List<BgmData> bgmData => data;
    }
}