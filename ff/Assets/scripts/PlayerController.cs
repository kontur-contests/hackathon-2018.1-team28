using System;
using System.Diagnostics.CodeAnalysis;
using Assets.scripts.helpers;
using UnityEngine;

namespace Assets.scripts
{
    [SuppressMessage("ReSharper", "UnassignedField.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class PlayerController : MonoBehaviour
    {
        private const float Epsilon = 0.001f;
        private float _moveX;
        private float _moveY;
        private Transform _trans;
        private Vector3 _positionOnScreen;
        private Vector3 _mouseOnScreen;
        private bool _moving;
        private bool _rotating;
        private AudioSource _steps;

        public float PlayerSpeed;
        public GameObject Bullet;

        private void Awake()
        {
            _trans = transform;
            _steps = GetComponent<AudioSource>();
            _moving = false;
            _rotating = false;
        }

        private void Update()
        {
            // calc move data
            _moveX = Input.GetAxis("Horizontal") * PlayerSpeed;
            _moveY = Input.GetAxis("Vertical") * PlayerSpeed;
            _moving = Mathf.Abs(_moveX) > Epsilon || Mathf.Abs(_moveY) > Epsilon;

            // calc rotate data
            _mouseOnScreen = Input.mousePosition;
            _positionOnScreen = Camera.main.WorldToScreenPoint(_trans.position);
            _rotating = Math.Abs(Input.GetAxis("Mouse X")) > Epsilon || Math.Abs(Input.GetAxis("Mouse Y")) > Epsilon;

            // steps sound
            _steps.mute = !(_moving || _rotating);
        }

        private void FixedUpdate()
        {
            Move();
            Rotate();
            Shoot();
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

        private void Shoot()
        {
            if (!Input.GetMouseButton(0)) return;

            var bullet = Instantiate(Bullet);
            var bulletController = bullet.GetComponent<BulletController>();
            bulletController.transform.position = transform.position;

            var shootVector = new Vector3(_mouseOnScreen.x - _positionOnScreen.x,
                _mouseOnScreen.y - _positionOnScreen.y, 0);
            bulletController.ShootAngle = Vector3.Normalize(shootVector);
        }
    }
}