using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _playerMoveSpeed = 5;
    [SerializeField] private int _jumpForce = 15;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private Vector2 GetInput()
    {
        Vector2 inputMap = new Vector2();
        inputMap.x = Input.GetAxisRaw("Horizontal");
        inputMap.y = Input.GetAxisRaw("Vertical");
        return inputMap;
    }
    
    void Update()
    {
        Move();
        Jump();        
    }

    private void Move()
    {
        Vector2 input = GetInput();
        Vector3 moveDirection = transform.forward * input.y + transform.right * input.x;
        moveDirection.Normalize();
        moveDirection.x *= _playerMoveSpeed;
        moveDirection.z *= _playerMoveSpeed;
        moveDirection.y = _rb.velocity.y;
        _rb.velocity = moveDirection;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
            _rb.AddForce(Vector3.up * _jumpForce);
    }
}
