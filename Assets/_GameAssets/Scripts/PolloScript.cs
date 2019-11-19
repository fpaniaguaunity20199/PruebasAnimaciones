using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolloScript : MonoBehaviour
{
    bool andando = false;
    public void Andar()
    {
        andando = true;
    }
    void Update()
    {
        if (andando)
        {
            transform.Translate(transform.forward * Time.deltaTime);
        }
    }
}
