using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remigio : MonoBehaviour
{
    private const string ANIM_STATE_REM_FALL_FLAT = "Fall Flat";
    private const string ANIM_STATE_REM_STAND_UP = "Standing Up";
    private const string ANIM_STATE_REM_KNOCK_OUT = "Knocked Out";

    private const string ANIM_PARAM_REM_TRIG_TRIPPING = "Tripping";
    private const string ANIM_PARAM_REM_TRIG_KO = "KO";

    private const string ANIM_PARAM_REM_BOOL_WALKING = "Walking";
    private const string ANIM_PARAM_REM_BOOL_RUNNING = "Running";
    private const string ANIM_PARAM_REM_BOOL_BACKWALKING = "BackWalking";

    private const float GAMEPAD_OFFSET = 0.1f;

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
        //Determinamos si no esta en un estado que impida el movimiento
        bool esMovible =
            animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != ANIM_STATE_REM_FALL_FLAT
            && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != ANIM_STATE_REM_STAND_UP
            && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != ANIM_STATE_REM_KNOCK_OUT;
        //Rotacion
        transform.Rotate(0, Input.GetAxis(Constantes.INPUT_HORIZONTAL) * angularSpeed * Time.deltaTime, 0);
        //Gestion del movimiento vertical
        if (Input.GetAxis(Constantes.INPUT_VERTICAL) > GAMEPAD_OFFSET && esMovible)
        {
            Walk();
        } else if (Input.GetAxis(Constantes.INPUT_VERTICAL) < -GAMEPAD_OFFSET && esMovible)
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
        if (other.gameObject.CompareTag(TagsManager.TAG_TROPIEZO))
        {
            animator.SetTrigger(ANIM_PARAM_REM_TRIG_TRIPPING);
        } else if (other.gameObject.CompareTag(TagsManager.TAG_OBSTACULO))
        {
            animator.SetTrigger(ANIM_PARAM_REM_TRIG_KO);
        }
    }
    /// <summary>
    /// Anda (o corre)
    /// </summary>
    private void Walk()
    {
        animator.SetBool(ANIM_PARAM_REM_BOOL_WALKING, true);
        animator.SetBool(ANIM_PARAM_REM_BOOL_RUNNING, Input.GetKey(KeyCode.LeftShift));
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
        animator.SetBool(ANIM_PARAM_REM_BOOL_BACKWALKING, true);
        transform.Translate(Vector3.back * walkSpeed * Time.deltaTime);
    }
    private void StopWalk()
    {
        animator.SetBool(ANIM_PARAM_REM_BOOL_WALKING, false);
        animator.SetBool(ANIM_PARAM_REM_BOOL_RUNNING, false);
        animator.SetBool(ANIM_PARAM_REM_BOOL_BACKWALKING, false);
    }
}
