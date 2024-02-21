using System.Collections;
using Unity;
using UnityEngine;
using static UnityEditor.PlayerSettings;
public class RedUnit : MonoBehaviour, IUnit
{
   
    private Vector3 pos;
    [SerializeField] private int moveSpeed = 10;
    private Rigidbody _rb;
    private void Awake()
    {
        pos = transform.position;
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
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

    
    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
  
}

