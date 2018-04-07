using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Assets.scripts
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnassignedField.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class PlayerData : MonoBehaviour
    {
        public int HealthPoint;
        public bool IsAlive => HealthPoint > 0;
    }
}
