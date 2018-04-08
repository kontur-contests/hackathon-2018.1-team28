using System;
using System.Diagnostics.CodeAnalysis;
using Assets.scripts.Helpers;
using UnityEngine;

namespace Assets.scripts
{
    [SuppressMessage("ReSharper", "UnassignedField.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    public class EnemyController : MonoBehaviour, IDamageable
    {
        private AudioSource _audio;
        private EnemyData _data;
        private GameObject _player;
        private SpawnerController _spawner;
        private bool IsAlive => _data.IsAlive;

        public void GetDamage(int damage)
        {
            _data.HealthPoint -= damage;

            if (!IsAlive)
                Die();
        }

        public void Die()
        {
            if (_data.DieSound != null)
            {
                _audio.clip = _data.DieSound;
                _audio.loop = false;
                _audio.Play();
            }

            Destroy(gameObject, 1);
            if (_spawner != null)
            {
                _spawner.Decrement();
            }

        }

        private void Awake()
        {
            _data = GetComponent<EnemyData>();
            _player = GameObject.FindGameObjectWithTag("Player");
            //_spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnerController>();
            _audio = GetComponent<AudioSource>();
            if (_data.MoveSound != null)
            {
                _audio.clip = _data.MoveSound;
                _audio.Play();
            }
        }

        public void SetSpawner(SpawnerController spawner)
        {
            _spawner = spawner;
        }

        private void FixedUpdate()
        {
            if (!CheckAlive())
                return;

            if (_data.EnableRotate)
                Rotate();

            Move();
        }

        private bool CheckAlive()
        {
            return IsAlive;
        }

        private void Move()
        {
            var step = _data.Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position,
                _player.transform.position.ChangeZ(transform.position.z), step);
        }

        private void Rotate()
        {
            var angle = MathHelper.AngleBetweenTwoPoints(_player.transform.position, transform.position);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!IsAlive) return;

            var damagedObject = col.gameObject.GetComponent<IDamageable>();
            if (damagedObject != null && !col.gameObject.CompareTag("Enemy"))
                damagedObject.GetDamage(_data.Damage);
        }
    }
}