using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEventCall : MonoBehaviour
{
    public void Shoot()
    {
        EnemyWeapons _parentScript = this.transform.parent.GetComponent<EnemyWeapons>();
        _parentScript.Shoot();
    }
}
