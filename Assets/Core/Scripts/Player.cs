using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private int _speed = 3;
    [SerializeField] private int _JumpForce = 20;
    [SerializeField] private int _coinsCollectable = 0;
    private PlayerInputAction _playerinputaction = new PlayerInputAction();

    private bool _canjump = false;

    private void Start()
    {

        _rigidbody = GetComponent<Rigidbody>();
        _playerinputaction = new PlayerInputAction();
        _playerinputaction.Player.Jump.performed += Jump_performed; ;
        
        _playerinputaction.Enable();
        
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        if (_canjump)
        {
            _rigidbody.AddForce(Vector3.up * _JumpForce); //new Vector3(0, 1, 0)
            _canjump = false;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer==LayerMask.NameToLayer("Floor"))
        {
            _canjump = true;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        throw new System.Exception();
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            _canjump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collectable"))
            _coinsCollectable++;
        Destroy(other.gameObject);
    }
    private void Update()
    {
        Vector2 direction = _playerinputaction.Player.Movement.ReadValue<Vector2>() * _speed;
        _rigidbody.linearVelocity = new Vector3(direction.x, _rigidbody.linearVelocity.y, direction.y);
    }
}
