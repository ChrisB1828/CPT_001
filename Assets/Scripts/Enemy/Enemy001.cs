using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy001 : Enemy
{
    private Vector3 _currentTarget;
    private Animator _anim;
    private SpriteRenderer _enemy001Sprite;
    private bool _waypoint;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _enemy001Sprite = GameObject.Find("Enemy001 sprite").GetComponent<SpriteRenderer>();
    }

    public override void Update()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle enemy001"))
        {
            return;
        }
        
        Movement();
    }

    void Movement()
    {
        if (transform.position == pointA.position)
        {
            _waypoint = false;

        }
        else if (transform.position == pointB.position)
        {
            _waypoint = true;

        }

        if (_waypoint == false)
        {
            _enemy001Sprite.flipX = false;
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
        }
        else if (_waypoint == true)
        {
            _enemy001Sprite.flipX = true;
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
        }

        if (transform.position == pointA.position && _waypoint == true)
        {
            _anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position && _waypoint == false)
        {
            _anim.SetTrigger("Idle");
        }
    }

    private void FlipEnemyAndMove(bool _isFlipped)
    {
        _enemy001Sprite.flipX = _isFlipped;
        transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
    }
}
