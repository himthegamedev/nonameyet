using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float _speed; 

    //[SerializeField]
    //private float _rotationSpeed;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _movement;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private const string _vertical = "horizontal";
    private const string _horizontal = "vertical";
    private const string _lasthorizontal = "lasthorizontal";
    private const string _lastvertical = "lastvertical";
    private Animator _animator;

    private void Update()
    {
        _movement.Set(InputManager.Movement.x, InputManager.Movement.y);
        _animator.SetFloat(_horizontal, _movement.x);
        _animator.SetFloat(_vertical, _movement.y);

        if (_movement != Vector2.zero)
        {
            _animator.SetFloat(_lasthorizontal, _movement.x);
            _animator.SetFloat(_lastvertical, _movement.y);
        }
    }




    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }



    private void FixedUpdate()
    {
        SetPlayerVelocity();
        //RotationInDirectionOfInput();
    }

    private void SetPlayerVelocity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _movementInput,
            ref _movementInputSmoothVelocity,
            0.1f);

        _rigidbody.velocity = _smoothedMovementInput * _speed;
    }

    //private void RotationInDirectionOfInput()
    //{
        //if (_movementInput != Vector2.zero)
        //{
           // Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothedMovementInput);
            //Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            //_rigidbody.MoveRotation(rotation);
        //}
    //}

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}



