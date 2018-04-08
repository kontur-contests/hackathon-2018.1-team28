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
        private Transform _trans;
        private EnemyData _data;
        private AudioSource _audio;
        private bool IsAlive => _data.IsAlive;
		private GameObject _player;
		private float _moveX;
		private float _moveY;

        private void Awake()
        {
            _data = GetComponent<EnemyData>();
			_player = GameObject.FindGameObjectWithTag("Player");
            _audio = GetComponent<AudioSource>();
            _audio.clip = _data.MoveSound;
            _audio.Play();
        }

		private void Update()
		{

		}

        private void FixedUpdate()
        {			
			if (!CheckAlive())
				return;
			
			Rotate ();
			Move();
        }

        private bool CheckAlive() => IsAlive;

		private void Move()
		{			
			var step = _data.Speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, _player.transform.position.ChangeZ(transform.position.z), step);
		}

		private void Rotate()
		{
			var angle = MathHelper.AngleBetweenTwoPoints(_player.transform.position, transform.position);
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		}

        private void OnTriggerEnter2D(Collider2D col)
        {
			if (IsAlive)
			{
				var damagedObject = col.gameObject.GetComponent<IDamageable> ();
			    if (damagedObject != null && !col.gameObject.CompareTag("Enemy"))
			    {
			        damagedObject.GetDamage(_data.Damage);
                }
			}
        }

        public void GetDamage(int damage)
        {
            _data.HealthPoint -= damage;
            Debug.Log(_data.HealthPoint);
            if (!IsAlive)
            {
                Die();
            }                
        }

        public void Die()
        {
            Debug.Log("Dead bug");
            _audio.clip = _data.DieSound;
            _audio.loop = false;
            _audio.Play();
            Destroy(gameObject, TimeSpan.FromSeconds(1).Ticks);            
        }
    }
}
