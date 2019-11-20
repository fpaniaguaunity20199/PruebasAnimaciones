using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remigio : MonoBehaviour
{
    private Animator animator;
    private float x;
    public float walkSpeed;
    public float runSpeed;
    public float angularSpeed;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * angularSpeed * Time.deltaTime, 0);
        if (Input.GetAxis("Vertical") > 0.1f 
            && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name!="Fall Flat" 
            && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name!="Standing Up"
            && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name!="Knocked Out")
        {
            Walk();
        } else if (Input.GetAxis("Vertical") < -0.1f
            && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Fall Flat"
            && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Standing Up"
            && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Knocked Out")
        {
            WalkBack();
        }
        else
        {
            StopWalk();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tropiezo"))
        {
            animator.SetTrigger("Tripping");
        } else if (other.gameObject.CompareTag("Obstaculo"))
        {
            animator.SetTrigger("KO");
        }
    }
    private void Walk()
    {
        animator.SetBool("Walking", true);
        animator.SetBool("Running", Input.GetKey(KeyCode.LeftShift));
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //Corriendo
            transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
        } else
        {
            //Andando
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
        }
    }
    private void WalkBack()
    {
        animator.SetBool("BackWalking", true);
        transform.Translate(Vector3.back * walkSpeed * Time.deltaTime);
    }
    private void StopWalk()
    {
        animator.SetBool("Walking", false);
        animator.SetBool("Running", false);
        animator.SetBool("BackWalking", false);
    }
}
