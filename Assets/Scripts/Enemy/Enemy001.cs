using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy001 : Enemy, IDamageable
{
    public int Health { get; set; }
    public override void Init() //use for initialization
    {
        base.Init();
        health = 100;
        Health = health;
    }

    public override void MovmentHit(Transform point)
    {
        base.MovmentHit(point);

        float distance = Vector3.Distance(player.transform.localPosition, transform.localPosition);

        //Debug.Log("Distance: " + distance);

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        Debug.Log("Direction: " + direction);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

}
