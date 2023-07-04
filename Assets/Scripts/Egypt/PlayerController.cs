using Egypt.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Egypt.PlayerControl
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float AnimBlendSpeed = 8.9f;
        [SerializeField] private Transform CameraRoot;
        [SerializeField] private Transform Camera;
        [SerializeField] private float UpperLimit = -40f;
        [SerializeField] private float BottomLimit = 70f;
        [SerializeField] private float MouseSensitivity = 21.9f; 


        private Rigidbody _playerRigidbody;
        private InputManager _inputManager;
        private Animator _animator;

        private bool _hasAnimator;
        private int _xvelHash;
        private int _yvelHash;
        private float _xRotation;

        private const float _walkSpeed = 2f;
        private const float _runSpeed = 6f;
        private Vector2 _currentVelocity;

        private void Start()
        {
            _hasAnimator = TryGetComponent<Animator>(out _animator);
            _playerRigidbody = GetComponent<Rigidbody>();
            _inputManager = GetComponent<InputManager>();

            _xvelHash = Animator.StringToHash("X_Velocity");
            _yvelHash = Animator.StringToHash("Y_Velocity");

        }

        private void FixedUpdate()
        {
            Move();
        }
        private void LateUpdate()
        {
            CamMovement();
        }

        private void Move()
        {
            if (!_hasAnimator) return;

            float targetSpeed = _inputManager.Run ? _runSpeed : _walkSpeed;
            if (_inputManager.Move == Vector2.zero) targetSpeed = 0.1f;

            _currentVelocity.x = Mathf.Lerp(_currentVelocity.x, _inputManager.Move.x * targetSpeed, AnimBlendSpeed * Time.fixedDeltaTime);
            _currentVelocity.y = Mathf.Lerp(_currentVelocity.y, _inputManager.Move.y * targetSpeed, AnimBlendSpeed * Time.fixedDeltaTime);
            

            var xvelDifference = _currentVelocity.x - _playerRigidbody.velocity.x;
            var zvelDifference = _currentVelocity.y - _playerRigidbody.velocity.z;

            _playerRigidbody.AddForce(transform.TransformVector(new Vector3(xvelDifference, 0, zvelDifference)), ForceMode.VelocityChange);

            _animator.SetFloat(_xvelHash, _currentVelocity.x);
            _animator.SetFloat(_yvelHash, _currentVelocity.y);

        }

        private void CamMovement()
        {
            if (!_hasAnimator) return;
            var Mouse_X = _inputManager.Look.x;
            var Mouse_Y = _inputManager.Look.y;
            Camera.position = CameraRoot.position;

            _xRotation -= Mouse_Y * MouseSensitivity * Time.deltaTime;
            _xRotation = Mathf.Clamp(_xRotation, UpperLimit, BottomLimit);

            Camera.localRotation = Quaternion.Euler(_xRotation, 0, 0);
            transform.Rotate(Vector3.up, Mouse_X * MouseSensitivity * Time.deltaTime);
        }
    }
}