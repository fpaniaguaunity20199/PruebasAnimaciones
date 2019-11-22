using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ludovico : MonoBehaviour
{
    public float pesoSpeed;
    private Animator animatorLudovico;
    private float peso=0.0f;
    void Start()
    {
        animatorLudovico = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            peso = peso + Time.deltaTime * pesoSpeed;
            peso = Mathf.Min(1, peso);
        } else
        {
            peso = peso - Time.deltaTime * pesoSpeed;
            peso = Mathf.Max(0, peso);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animatorLudovico.SetBool("Running", true);
        } else if (Input.GetKeyUp(KeyCode.Space))
        {
            animatorLudovico.SetBool("Running", false);
        }
        animatorLudovico.SetLayerWeight(1, peso);
    }
}
