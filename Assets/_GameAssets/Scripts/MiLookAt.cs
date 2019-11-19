using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiLookAt : MonoBehaviour
{
    public Transform transformPollo;
    
    void Update()
    {
        transform.LookAt(transformPollo);
    }
}
