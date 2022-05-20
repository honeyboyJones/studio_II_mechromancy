using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeelaAnimator : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    private TitanfallMovement movement;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        rigidbody = this.gameObject.GetComponentInParent<Rigidbody>();
        movement = this.gameObject.GetComponentInParent<TitanfallMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rigidbody.velocity.magnitude);
        animator.SetFloat("speed", rigidbody.velocity.magnitude);
        if (movement.mode == TitanfallMovement.Mode.Flying)
        {
            animator.SetBool("isgrounded", false);
        }
        else 
        {
            animator.SetBool("isgrounded", true);
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            animator.SetBool("isjump", true);
            
        }

        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            animator.SetBool("isjump", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetFloat("multiplier", -1f);
        }
        else 
        {
            animator.SetFloat("multiplier", 1f);
        }
    }
}
