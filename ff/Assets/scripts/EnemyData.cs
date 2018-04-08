using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.scripts
{
    [PublicAPI]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnassignedField.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class EnemyData : MonoBehaviour
    {
        public int Damage;
        public int HealthPoint;
        public AudioClip MoveSound;
        public AudioClip DieSound;

        public bool IsAlive => HealthPoint > 0;
		public float Speed;
    }
}