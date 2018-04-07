using System.Diagnostics.CodeAnalysis;
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
            _moveX = Input.GetAxis("Horizontal") * PlayerSpeed;
            _moveY = Input.GetAxis("Vertical") * PlayerSpeed;
        }

        private void FixedUpdate()
        {
            _trans.position = _trans.position.AddValueXY(_moveX, _moveY);
        }
    }
}
