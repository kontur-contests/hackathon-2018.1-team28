using System.Diagnostics.CodeAnalysis;
using Assets.scripts.Helpers;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.scripts
{
    [PublicAPI]
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    [SuppressMessage("ReSharper", "UnassignedField.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class CameraController : MonoBehaviour
    {

        public Transform FollowWhom;
        public float NoMoveShift;
		public float MovementResponseSpeed = 1;

        private Transform _trans;

        private void Awake()
        {
            _trans = transform;
        }

        private void FixedUpdate()
        {
            ShiftX();
            ShiftY();
            CheckEscapeButton();
        }

        private void CheckEscapeButton()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            }
        }

        private void ShiftX()
        {
            if (!(Mathf.Abs(_trans.position.x - FollowWhom.position.x) > NoMoveShift))
                return;

			var xpos = Mathf.Lerp(_trans.position.x, FollowWhom.position.x, Time.deltaTime * MovementResponseSpeed);
            _trans.position = _trans.position.ChangeX(xpos);
        }
        private void ShiftY()
        {
            if (!(Mathf.Abs(_trans.position.y - FollowWhom.position.y) > NoMoveShift))
                return;

			var ypos = Mathf.Lerp(_trans.position.y, FollowWhom.position.y, Time.deltaTime * MovementResponseSpeed);
            _trans.position = _trans.position.ChangeY(ypos);
        }
    }
}
