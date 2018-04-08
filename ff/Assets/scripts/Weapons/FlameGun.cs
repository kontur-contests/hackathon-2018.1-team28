using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.scripts.Weapons
{
    [PublicAPI]
    [SuppressMessage("ReSharper", "UnassignedField.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class FlameGun : MonoBehaviour, IWeapon
    {

        public GameObject Bullet;
        public float FireDelay;

        public float GetFireDelay() => FireDelay;

        public GameObject GetBullet() => Bullet;

        public void Shoot(Vector3 startPosition, Vector3 shootAngle)
        {
            var bullet = Instantiate(Bullet);
            var bulletController = bullet.GetComponent<BulletController>();
            bulletController.transform.position = startPosition;
            bulletController.ShootAngle = shootAngle;
        }
    }
}
