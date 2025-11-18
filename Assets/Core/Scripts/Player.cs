using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private int _speed = 3;
    [SerializeField] private int _JumpForce = 10;
    private PlayerInputAction _playerinputaction = new PlayerInputAction();

    private void Start()
    {

        _rigidbody = GetComponent<Rigidbody>();
        _playerinputaction = new PlayerInputAction();
        _playerinputaction.Player.Jump.performed += Jump_performed; ;
        
        _playerinputaction.Enable();
        
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        _rigidbody.AddForce(Vector3.up * _JumpForce); //new Vector3(0, 1, 0)
    }

    private void Update()
    {
        Vector2 direction = _playerinputaction.Player.Movement.ReadValue<Vector2>() * _speed;
        _rigidbody.linearVelocity = new Vector3(direction.x, _rigidbody.linearVelocity.y, direction.y);
    }
}
//    private void Update()
//    {
//        Vector3 direction = Vector3.zero;

//        if (Input.GetKey(KeyCode.W))
//        {
//            direction += new Vector3(1, 0, 0) * _speed;
//        }

//        if (Input.GetKey(KeyCode.S))
//        {
//            direction += new Vector3(-1, 0, 0) * _speed;
//        }

//        if (Input.GetKey(KeyCode.A))
//        {
//            direction += new Vector3(0, 0, 1) * _speed;
//        }

//        if (Input.GetKey(KeyCode.D))
//        {
//            direction += new Vector3(0, 0, -1) * _speed;
//        }

//        _rigidbody.linearVelocity = new Vector3(direction.x, _rigidbody.linearVelocity.y, direction.z);  
//    }
//}
