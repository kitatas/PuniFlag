using System.Collections.Generic;
using UnityEngine;

namespace Common.Data.DataStore
{
    [CreateAssetMenu(fileName = "SeTable", menuName = "DataTable/SeTable", order = 0)]
    public sealed class SeTable : ScriptableObject
    {
        [SerializeField] private List<SeData> data = default;

        public List<SeData> seData => data;
    }
}