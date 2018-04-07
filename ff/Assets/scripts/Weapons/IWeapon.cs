using UnityEngine;

namespace Assets.scripts.Weapons
{
    public interface IWeapon
    {
        float GetFireDelay();
        GameObject GetBullet();
    }
}