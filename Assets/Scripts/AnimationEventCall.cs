using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventCall : MonoBehaviour
{

    void Update()
    {

    }

    public void Shoot()
    {
        Weapons _parentScript = this.transform.parent.GetComponent<Weapons>();
        _parentScript.Shoot();
    }
}
