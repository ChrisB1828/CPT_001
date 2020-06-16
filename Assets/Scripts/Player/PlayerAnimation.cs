using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }
    public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void JumpAnim()
    {
        _anim.SetTrigger("Jumping"); //(parameter from unity, bool jumping)
    }

    public void Attack()
    {
        _anim.SetTrigger("Attack");
    }
}
