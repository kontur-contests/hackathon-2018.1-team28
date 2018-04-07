using UnityEngine;

namespace Assets.scripts.Weapons
{
    public class Pistol : MonoBehaviour, IWeapon
    {
        public float FireDelay;
        public GameObject Bullet;

        public float GetFireDelay() => FireDelay;
        public GameObject GetBullet() => Bullet;
    }
}
