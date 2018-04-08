using UnityEngine;

namespace Assets.scripts.Weapons
{
    public interface IWeapon
    {
        float GetFireDelay();
        GameObject GetBullet();
        void Shoot(Vector3 startPosition, Vector3 shootAngle);
    }
}