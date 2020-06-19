using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile1 : MonoBehaviour
{
    public float _speed = 10f;
    public int _damage = 10;

    public Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody.velocity = transform.right * _speed;
    }

    void OnTriggerEnter2D(Collider2D _hitInfo)
    {

        Enemy enemy = _hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }

}
