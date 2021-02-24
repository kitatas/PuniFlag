using Common.Extension;
using UnityEngine;

namespace Game.Stage
{
    public sealed class Flag : MonoBehaviour
    {
        public bool EqualPosition(Vector3 playerPosition) => transform.RoundPosition() == playerPosition;
    }
}