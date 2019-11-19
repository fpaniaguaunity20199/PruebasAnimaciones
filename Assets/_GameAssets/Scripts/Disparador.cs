using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    public Animator animatorOtroCubo;
    public void ArrancarSegundoCubo()
    {
        animatorOtroCubo.enabled = true;
    }
}
