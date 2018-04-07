using UnityEngine;

namespace Assets.scripts.Weapons
{
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