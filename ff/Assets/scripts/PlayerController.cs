using System.Diagnostics.CodeAnalysis;
using Assets.scripts.helpers;
using UnityEngine;

namespace Assets.scripts
{
    [SuppressMessage("ReSharper", "UnassignedField.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class PlayerController : MonoBehaviour
    {
        private float _moveX;
        private float _moveY;
        private Transform _trans;
        private Vector3 _positionOnScreen;
        private Vector3 _mouseOnScreen;

        public float PlayerSpeed;
        public GameObject Bullet;

        private void Awake()
        {
            _trans = transform;
        }

        private void Update()
        {
            // calc move data
            _moveX = Input.GetAxis("Horizontal") * PlayerSpeed;
            _moveY = Input.GetAxis("Vertical") * PlayerSpeed;

            // calc rotate data
            _mouseOnScreen = Input.mousePosition;
            _mouseOnScreen.z = 5.23f; //The distance between the camera and object
            _positionOnScreen = Camera.main.WorldToScreenPoint(_trans.position);
            var angle = MathHelper.AngleBetweenTwoPoints(_mouseOnScreen, _positionOnScreen);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        private void FixedUpdate()
        {
            Move();
            Shoot();
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