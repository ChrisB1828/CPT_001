﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventCall : MonoBehaviour
{

    public void Shoot()
    {
        Weapons _parentScript = this.transform.parent.GetComponent<Weapons>();
        _parentScript.Shoot();
    }
}
