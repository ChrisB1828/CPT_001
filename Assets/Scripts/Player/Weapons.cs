using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public Transform _firePoint;
    public GameObject _projectilePrefab;
    public float _fireRate = 1F;
    public float _nextFire = 0.0f; 

    void Update()
    {
        //Shoot();
    }


    public void Shoot()
    {
        Instantiate(_projectilePrefab, _firePoint.position, _firePoint.rotation);
    }
}
