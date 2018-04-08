using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Assets.scripts.Helpers;
using Assets.scripts.Weapons;
using UnityEngine;

namespace Assets.scripts
{
    [SuppressMessage("ReSharper", "UnassignedField.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    public class PlayerController : MonoBehaviour, IDamageable
    {
        private const float Epsilon = 0.001f;
        private bool _canShot;
        private Vector3 _mouseOnScreen;
        private float _moveX;
        private float _moveY;
        private bool _moving;
        private Vector3 _positionOnScreen;
        private bool _rotating;
        private bool IsAlive => _playerData.IsAlive;
        private AudioSource _audio;
        private Transform _trans;
        private IWeapon _weapon;
        private PlayerData _playerData;

        private GameObject _alivePic;
        private GameObject _deadPic;
        private GameObject _bulletSpawnPlace;

        public float PlayerSpeed;
        public GameObject Weapon;

        private void Awake()
        {
            _trans = transform;
            _bulletSpawnPlace = GetComponentsInChildren<Transform>().FirstOrDefault(tr => tr.CompareTag("bulletSpawn"))?.gameObject;
            _alivePic = GetComponentsInChildren<Transform>().FirstOrDefault(tr => tr.CompareTag("alive"))?.gameObject;
            _deadPic = GetComponentsInChildren<Transform>().FirstOrDefault(tr => tr.CompareTag("dead"))?.gameObject;
            _deadPic?.SetActive(false);

            _playerData = GetComponent<PlayerData>();
            _weapon = Weapon.GetComponent<IWeapon>();

            _audio = GetComponent<AudioSource>();
            _audio.clip = _playerData.MoveSound;
            _audio.Play();

            _moving = false;
            _rotating = false;
            _canShot = true;

            //Invoke(nameof(Die), 1);
        }

        private void Update()
        {
            if (!IsAlive)
                return;

            // calc move data
            _moveX = Input.GetAxis("Horizontal") * PlayerSpeed;
            _moveY = Input.GetAxis("Vertical") * PlayerSpeed;
            _moving = Mathf.Abs(_moveX) > Epsilon || Mathf.Abs(_moveY) > Epsilon;

            // calc rotate data
            _mouseOnScreen = Input.mousePosition;
            _positionOnScreen = Camera.main.WorldToScreenPoint(_trans.position);
            _rotating = Math.Abs(Input.GetAxis("Mouse X")) > Epsilon || Math.Abs(Input.GetAxis("Mouse Y")) > Epsilon;

            // steps sound
            _audio.mute = !(_moving || _rotating);
        }

        private void FixedUpdate()
        {
            if (!IsAlive)
                return;

            CheckShoot();
            Move();
            Rotate();
        }

        private void Rotate()
        {
            var angle = MathHelper.AngleBetweenTwoPoints(_mouseOnScreen, _positionOnScreen);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        private void Move()
        {
            _trans.position = _trans.position.AddValueXY(_moveX, _moveY);
        }

        private void CheckShoot()
        {
            if (!Input.GetMouseButton(0))
                return;

            if (_canShot)
                StartCoroutine(Shoot());
        }

        public IEnumerator Shoot()
        {
            var shootVector = new Vector3(_mouseOnScreen.x - _positionOnScreen.x,
                _mouseOnScreen.y - _positionOnScreen.y, 0);
            var shootAngle = Vector3.Normalize(shootVector);

            _weapon.Shoot(_bulletSpawnPlace.transform.position, shootAngle);

            _canShot = false;
            yield return new WaitForSeconds(_weapon.GetFireDelay());
            _canShot = true;
        }

        public void GetDamage(int damage)
        {
            _playerData.HealthPoint -= damage;
            if (!IsAlive)
                Die();
        }

        public void Die()
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
            _deadPic.SetActive(true);
            _alivePic.SetActive(false);
            _audio.clip = _playerData.DieSound;
            _audio.loop = false;
            _audio.Play();
        }
    }
}