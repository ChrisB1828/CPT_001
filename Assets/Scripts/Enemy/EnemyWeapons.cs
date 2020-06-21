using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapons : MonoBehaviour
{
    public Transform _firePoint;
    public GameObject _attackPrefab;

    public void Shoot()
    {
        Instantiate(_attackPrefab, _firePoint.position, _firePoint.rotation);
    }
}
