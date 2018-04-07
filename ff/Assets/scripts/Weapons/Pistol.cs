using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.scripts.Weapons
{
    [PublicAPI]
    [SuppressMessage("ReSharper", "UnassignedField.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class Pistol : MonoBehaviour, IWeapon
    {
        public GameObject Bullet;
        public float FireDelay;

        public float GetFireDelay()
        {
            return FireDelay;
        }

        public GameObject GetBullet()
        {
            return Bullet;
        }
    }
}