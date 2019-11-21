using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wenceslao2D : MonoBehaviour
{
    float h, v;//Horizontal, vertical
    Animator wenceslaoAnimator;
    const string PARAM_HORIZONTAL = "Horizontal";
    const string PARAM_VERTICAL = "Vertical";
    bool walking = false;
    const float V_OFFSET = 0.1f;
    float speed = 0;
    public float aceleracion;
    public float delay;
    void Start()
    {
        wenceslaoAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        //Comienzo a andar
        if (!walking && v > V_OFFSET)
        {
            walking = true;
            StopCoroutine("Desacelerar");
            StartCoroutine("Acelerar");
        } 
        //Comienzo a parar
        if (walking && v < V_OFFSET)
        {
            walking = false;
            StopCoroutine("Acelerar");
            StartCoroutine("Desacelerar");
        }
    }
    private IEnumerator Acelerar()
    {
        while (true)
        {
            speed = speed + aceleracion;
            speed = Mathf.Min(speed, v);
            wenceslaoAnimator.SetFloat(PARAM_FORWARD, speed);
            yield return new WaitForSeconds(delay);
        }
    }
    private IEnumerator Desacelerar()
    {
        while (true)
        {
            speed = speed - aceleracion;
            speed = Mathf.Max(speed, v);
            wenceslaoAnimator.SetFloat(PARAM_FORWARD, speed);
            yield return new WaitForSeconds(delay);
        }
    }
}
