using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adam : MonoBehaviour
{
    bool enPosSaltoObstaculoBajo = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (enPosSaltoObstaculoBajo)
            {
                GetComponent<Animator>().SetTrigger("Saltar");
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("ObstaculoBajo"))
        {
            enPosSaltoObstaculoBajo = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ObstaculoBajo"))
        {
            enPosSaltoObstaculoBajo = false;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("ObstaculoBajo"))
    //    {
    //        print("SALTANDO UN OBSTACULO BAJO");
    //        GetComponent<Animator>().SetTrigger("Saltar");
    //    }
    //    if (other.CompareTag("ObstaculoAlto"))
    //    {
    //        print("SALTANDO UN OBSTACULO ALTO");
    //        GetComponent<Animator>().SetTrigger("Subir");
    //    }
    //}
}
