using System.Collections;
using System.Collections.Generic;
// EnemyController.cs
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    public float changeDirectionTime = 2f;
    private Vector3 currentDirection;
    private float timer;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ChangeDirection();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeDirectionTime)
        {
            ChangeDirection();
            timer = 0;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + currentDirection * speed * Time.fixedDeltaTime);
    }

    void ChangeDirection()
    {
        int dir = Random.Range(0, 4);
        switch (dir)
        {
            case 0: currentDirection = Vector3.forward; break;
            case 1: currentDirection = Vector3.back; break;
            case 2: currentDirection = Vector3.left; break;
            case 3: currentDirection = Vector3.right; break;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            ChangeDirection();
        }
    }
}
