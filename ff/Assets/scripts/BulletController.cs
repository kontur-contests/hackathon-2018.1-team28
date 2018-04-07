using System.Collections;
using UnityEngine;

namespace Assets.scripts
{
    public class BulletController : MonoBehaviour
    {
        public Vector3 ShootAngle;
        public float MaxLifetime;
        public float Speed;

        private void Start()
        {
            StartCoroutine(KillItSelf());
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            transform.position += ShootAngle * Speed;
        }

        private IEnumerator KillItSelf()
        {
            yield return new WaitForSeconds(MaxLifetime);
            Destroy(gameObject);
        }
    }
}