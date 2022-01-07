using Assets.CameraConfigs;
using Assets.Interfaces;
using Assets.Resources;
using UnityEngine;

namespace Assets.Sphere
{
    public class SphereMove : MonoBehaviour
    {
        public CharacterController CharacterController;

        public float MovementSpeed;

        private IInputService _inputService;
        private Camera _camera;

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
            if (_inputService.Axis.sqrMagnitude > 0)
            {
                vector = _camera.transform.TransformDirection(_inputService.Axis);
                vector.y = 0;
                vector.Normalize();
                
                transform.forward = vector;

                vector += Physics.gravity;
            }
            CharacterController.Move(MovementSpeed * vector * time);
        }

        private void InitializeCamera()
        {
            _camera = Camera.main;
            _camera.GetComponent<CameraFollow>().Follow(gameObject);
        }
    }
}