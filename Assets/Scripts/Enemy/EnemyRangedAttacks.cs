using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttacks : MonoBehaviour
{
    public int _damage = 10;

    private bool _canDamge = true;
    private Animator _anim;

    public Rigidbody2D _rigidbody;

    private void Update()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

    void OnTriggerEnter2D(Collider2D _hitInfo)
    {
        IDamageable hit = _hitInfo.GetComponent<IDamageable>();

        if (hit != null)
        {
            hit.TakeDamage(_damage);

            //if (_canDamge == true)
            //{
                //hit.TakeDamage(_damage);
                //_canDamge = false;
                //StartCoroutine(ResetDamage());
            //}
        }
    }

    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamge = true;
    }
}
