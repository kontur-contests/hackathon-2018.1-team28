using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Assets.scripts
{
    [SuppressMessage("ReSharper", "UnassignedField.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    public class EnemyController : MonoBehaviour, IDamageable
    {
        private Transform _trans;
        private EnemyData _data;
        private AudioSource _audio;
        private bool IsAlive => _data.IsAlive;

        private void Awake()
        {
            _trans = transform;
            _data = GetComponent<EnemyData>();
            _audio = GetComponent<AudioSource>();
            _audio.clip = _data.MoveSound;
            _audio.Play();
        }

        private void FixedUpdate()
        {
            if (!IsAlive)
                return;

            CheckAlive();
        }

        private void CheckAlive()
        {
            if (IsAlive)
                return;

            Die();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            var damagedObject = col.gameObject.GetComponent<IDamageable>();
            damagedObject?.GetDamage(_data.Damage);
        }

        public void GetDamage(int damage)
        {
            _data.HealthPoint -= damage;
            Debug.Log(_data.HealthPoint);
            if (!IsAlive)
                Die();
        }

        public void Die()
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
            _audio.clip = _data.DieSound;
            _audio.loop = false;
            _audio.Play();
        }
    }
}
