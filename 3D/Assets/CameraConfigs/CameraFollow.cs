using UnityEngine;

namespace CameraConfigs
{
    public class CameraFollow : MonoBehaviour
    {
        public float Distance;
        public float CameraAngleX;
        public float CameraWeigth;

        [SerializeField]
        private Transform _player;
        private Vector3 _playerPreviousPosition;

        public void Follow(GameObject gameObject)
        {
            _player = gameObject.transform;
            _playerPreviousPosition = _player.transform.position;
        }

        private void LateUpdate()
        {
            if (_player == null)
            {
                return;
            }
            var cameraRotation = Quaternion.Euler(0, CameraAngleX, 0);
            var playerMoveDirection = GetPlayerMoveDirection();
            var cameraPosition = GetCameraPosition(playerMoveDirection);

            ChangeCameraPosition(cameraPosition, cameraRotation);

            SetupPlayerPreviousPosition();
        }

        private void SetupPlayerPreviousPosition()
        {
            _playerPreviousPosition = _player.transform.position;
        }

        private Vector3 GetPlayerMoveDirection()
        {
            var playerMoveDirection = _player.transform.position - _playerPreviousPosition;
            playerMoveDirection.Normalize();
            return playerMoveDirection;
        }

        private Vector3 GetCameraPosition(Vector3 playerMoveDirection)
        {
            var cameraPosition = _player.transform.position - playerMoveDirection * Distance;
            cameraPosition.y += CameraWeigth;
            return cameraPosition;
        }

        private void ChangeCameraPosition(Vector3 cameraPosition, Quaternion cameraRotation)
        {
            transform.SetPositionAndRotation(cameraPosition, cameraRotation);
            transform.LookAt(_player.transform.position);
        }
    }
}
