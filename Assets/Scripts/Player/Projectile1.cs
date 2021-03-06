﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile1 : MonoBehaviour
{
    public float _speed = 10f;
    public int _damage = 10;

    private bool _canDamge = true;

    public Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody.velocity = transform.right * _speed;
    }

    void OnTriggerEnter2D(Collider2D _hitInfo)
    {
        IDamageable hit = _hitInfo.GetComponent<IDamageable>();

        if (hit != null)
        {
            if (_canDamge == true)
            {
                hit.TakeDamage(_damage);
                _canDamge = false;
                StartCoroutine(ResetDamage());
            } 
        }

        Destroy(gameObject);
    }

    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamge = true;
    }
}
