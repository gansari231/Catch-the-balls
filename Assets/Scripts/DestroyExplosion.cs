﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3); // destroy particle after 2 seconds
    }


}
