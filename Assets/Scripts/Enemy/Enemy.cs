using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
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
    protected bool waypoint;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        Init();
    }
    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle enemy"))
        {
            return;
        }

        Movment();
    }

    public virtual void Movment()
    {
        if (transform.position == pointA.position)
        {
            waypoint = false;

        }
        else if (transform.position == pointB.position)
        {
            waypoint = true;

        }

        if (waypoint == false)
        {
            sprite.flipX = false;
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
        }
        else if (waypoint == true)
        {
            sprite.flipX = true;
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
        }

        if (transform.position == pointA.position && waypoint == true)
        {
            anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position && waypoint == false)
        {
            anim.SetTrigger("Idle");
        }
    }

    public virtual void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
