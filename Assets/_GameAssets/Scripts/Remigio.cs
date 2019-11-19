using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remigio : MonoBehaviour
{
    private Animator animator;
    private float x;
    public float angularSpeed;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * angularSpeed * Time.deltaTime, 0);
        if (Input.GetAxis("Vertical") > 0.1f)
        {
            Walk();
        } else
        {
            StopWalk();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tropiezo"))
        {
            animator.SetTrigger("Tripping");
        }
    }
    private void Walk()
    {
        animator.SetBool("Walking", true);
        animator.SetBool("Running", Input.GetKey(KeyCode.LeftShift));
    }
    private void StopWalk()
    {
        animator.SetBool("Walking", false);
        animator.SetBool("Running", false);
    }

}
