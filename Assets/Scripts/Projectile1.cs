using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile1 : MonoBehaviour
{
    public float _speed = 10f;
    public Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody.velocity = transform.right * _speed;
    }

    void OnTriggerEnter2D(Collider2D _hitInfo)
    {
        Destroy(gameObject);
    }

}
