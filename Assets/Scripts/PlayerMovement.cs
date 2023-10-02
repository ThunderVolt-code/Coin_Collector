using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
public CharacterController2D controller;
public Animator animator;
public float speed = 40f;
float hMove = 0f;
bool isjump = false;
bool iscrouch = false;


    // Update is called once per frame
    void Update()
    {
       hMove =  Input.GetAxisRaw("Horizontal") * speed;

       animator.SetFloat("Speed", Mathf.Abs(hMove));

       if(Input.GetButtonDown("Jump"))
       {
        isjump = true;
        animator.SetBool("InAir", true);
       }
       
       if(Input.GetButtonDown("Crouch"))
       {
            iscrouch = true;
       }else if(Input.GetButtonUp("Crouch"))
       {
            iscrouch = false;
       }

    }

    public void OnLanding()
    {
       animator.SetBool("InAir", false);
    }

    public void OnCrouch(bool IsCrouching)
    {
        animator.SetBool("IsCrouch", IsCrouching);
    }

    void FixedUpdate ()
    {
        controller.Move(hMove * Time.fixedDeltaTime, iscrouch, isjump);
        isjump = false;
    }
}
