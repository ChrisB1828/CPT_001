﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public GameObject gemPrefab;

    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected bool currentPosition;

    protected bool isHit;

    protected Player player;

    private bool _facingRight = true;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();//Need to check if I can delete this
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Start()
    {
        Init();
    }
    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle enemy") && anim.GetBool("InCombat") == false)
        {
            return;
        }

        Movment();
    }

    public virtual void Movment() // NEED TO OPTIMIZE THIS CODE SOMEHOW?????!!!!!!!!!!!! When optimizing it is not working corcectly.
    {      
        if (transform.position == pointA.position)
        {
            currentPosition = false;
        }
        else if (transform.position == pointB.position)
        {
            currentPosition = true;
        }

        if (currentPosition == false)
        {
            MovmentHit(pointB);

            if (!_facingRight)
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("EnemyAttack") && anim.GetBool("InCombat") == false)
                {
                    return;
                }
                Flip();
            }
        }
        else if (currentPosition == true)
        {
            MovmentHit(pointA);

            if (_facingRight)
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("EnemyAttack") && anim.GetBool("InCombat") == false)
                {
                    return;
                }
                Flip();
            }
        }

        if (transform.position == pointA.position && currentPosition == true && !_facingRight && anim.GetBool("InCombat") == false)
        {
            anim.SetTrigger("Idle");
            StartCoroutine(WaitAMomentForFlip());   
        }
        else if (transform.position == pointB.position && currentPosition == false && _facingRight && anim.GetBool("InCombat") == false)
        {
            anim.SetTrigger("Idle");
            StartCoroutine(WaitAMomentForFlip());
        }

        InCombatFlip();
    }

    public virtual void MovmentHit(Transform point)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("EnemyAttack") && anim.GetBool("InCombat") == false)
        {
            return;
        }

        if (isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(player.transform.localPosition, transform.localPosition);
        
        if (anim.GetBool("InCombat") == true && distance > 20.0F)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        isHit = true;
        anim.SetTrigger("Hit");
        anim.SetBool("InCombat", true);

        anim.SetTrigger("Hit");

        if (health <= 0)
        {
            GameObject gem = Instantiate(gemPrefab, transform.position, Quaternion.identity) as GameObject;
            gem.GetComponent<Crystals>().crystal = gems;
            Destroy(gameObject);
        }
    }

    public void AttackAnimEnded() 
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("EnemyAttack") && anim.GetBool("InCombat") == false)
        {
            return;
        }
    }

    public void InCombatFlip()
    {
        Vector3 direction = player.transform.localPosition - transform.localPosition;

        if (direction.x > 0 && anim.GetBool("InCombat") == true && _facingRight)
        {
            return;

        }
        else if (direction.x > 0 && anim.GetBool("InCombat") == true && !_facingRight)
        {
            Flip();
        }
        else if (direction.x < 0 && anim.GetBool("InCombat") == true && _facingRight)
        {
            Flip();
        }
        else if (direction.x < 0 && anim.GetBool("InCombat") == true && !_facingRight)
        {
            return;
        }
    }

    public void Flip()
    {
        _facingRight = !_facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    IEnumerator WaitAMomentForFlip() 
    {
        yield return new WaitForSeconds(0.7f);
        Flip();
    }

}
