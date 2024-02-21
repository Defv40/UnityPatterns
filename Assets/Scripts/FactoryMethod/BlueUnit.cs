using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueUnit : MonoBehaviour
{

    private Vector3 pos;
    [SerializeField] private int moveSpeed = 10;
    private Rigidbody _rb;
    [SerializeField] private int jumpForce = 5;
    private void Awake()
    {
        pos = transform.position;
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        StartCoroutine(Jump());
        StartCoroutine(LifeTime());
    }

    public void Move()
    {
        Vector3 dir = (transform.forward + transform.right).normalized;
        dir.y = _rb.velocity.y;
        dir.x *= moveSpeed;
        _rb.velocity = dir;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private IEnumerator Jump()
    {
        yield return new WaitForSeconds(1);
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        yield return new WaitForSeconds(1);
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        yield return new WaitForSeconds(1);
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }

}
