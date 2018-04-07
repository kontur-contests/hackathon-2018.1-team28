using System.Diagnostics.CodeAnalysis;
using Assets.scripts.helpers;
using UnityEngine;

namespace Assets.scripts
{
    [SuppressMessage("ReSharper", "UnassignedField.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class PlayerController : MonoBehaviour
    {
        public float PlayerSpeed;
        private Transform _trans;
        private float _moveX = 0f;
        private float _moveY = 0f;

        private void Awake()
        {
            _trans = transform;
        }

        private void Update()
        {
            // move
            _moveX = Input.GetAxis("Horizontal") * PlayerSpeed;
            _moveY = Input.GetAxis("Vertical") * PlayerSpeed;

            // rotate
            var positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
            var mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

            var angle = MathHelper.AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }

        private void FixedUpdate()
        {
            _trans.position = _trans.position.AddValueXY(_moveX, _moveY);
        }
    }
}