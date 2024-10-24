using UnityEngine;

namespace Source.Input
{
    using Input = UnityEngine.Input;
    
    // gpt3 based telegram bot made it, looks pretty good
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _sensitivity = 1f;

        [SerializeField] private UnityEngine.CharacterController _controller;
        [SerializeField] private Camera _playerCamera;
        [SerializeField] private float _verticalRotation = 0f;

        private void Update()
        {
            Move();
            Look();
        }

        private void Move()
        {
            var moveX = Input.GetAxis("Horizontal"); // A/D keys
            var moveZ = Input.GetAxis("Vertical"); // W/S keys
            var move = transform.right * moveX + transform.forward * moveZ + transform.up * -1;
        
            _controller.Move(move * (_moveSpeed * Time.deltaTime));
        }

        private void Look()
        {
            var mouseX = Input.GetAxis("Mouse X") * _sensitivity;
            var mouseY = Input.GetAxis("Mouse Y") * _sensitivity;
        
            _verticalRotation -= mouseY;
            _verticalRotation = Mathf.Clamp(_verticalRotation, -70f, 70f); // Limit up/down look
            _playerCamera.transform.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
    }
}
