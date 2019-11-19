using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public PolloScript polloScript;
    public void ArrancarPollo()
    {
        polloScript.Andar();
    }
}
