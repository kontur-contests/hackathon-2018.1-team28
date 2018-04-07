using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.scripts
{
    [PublicAPI]
    [SuppressMessage("ReSharper", "UnassignedField.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    public class BulletController : MonoBehaviour
    {
        public float MaxLifetime;
        public Vector3 ShootAngle;
        public float Speed;

        private void Start()
        {
            Invoke(nameof(Destroy), MaxLifetime);
        }

        private void FixedUpdate()
        {
            transform.position += ShootAngle * Speed;
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}