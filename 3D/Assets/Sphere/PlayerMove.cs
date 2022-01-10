using CameraConfigs;
using Interfaces;
using Resources;
using UnityEngine;

namespace Sphere
{
    public class PlayerMove : MonoBehaviour
    {
        public CharacterController CharacterController;

        public float MovementSpeed;

        private IInputService _inputService;
        private Camera _camera;
        private float _zero = 0.001f;

        private void Start()
        {
            InitializeCamera();
        }

        private void Awake()
        {
            _inputService = Game.InputService;
        }

        private void Update()
        {
            var time = Time.deltaTime;
            var vector = Vector3.zero;
            if (_inputService.Axis.sqrMagnitude > _zero)
            {
                vector = new Vector3(_inputService.Axis.x, 0, _inputService.Axis.y);
                vector.Normalize();
                transform.forward = vector;

                vector += Physics.gravity;
            }
            CharacterController.Move(MovementSpeed * vector * time);
        }

        private void InitializeCamera()
        {
            _camera = Camera.main;
            if (_camera != null) _camera.GetComponent<CameraFollow>().Follow(gameObject);
        }
    }
}