﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller; 

    public float runSpeed = 40f;
    float horizontalMove = 0f;

    bool jump = false;
    public Animator anim;
    public AudioSource walkSound;
    public AudioSource jumpSound;
    
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        anim.SetBool("Moving", horizontalMove != 0);
        if(horizontalMove != 0 && !walkSound.isPlaying && controller.m_Grounded)
        {
            walkSound.volume = Random.Range(.8f, 1f);
            walkSound.pitch = Random.Range(.8f, 1.1f);
            walkSound.Play();
        }
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate ()
    {
        //moves character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        if(controller.m_Grounded && Input.GetButtonDown("Jump"))
        {
            jumpSound.volume = Random.Range(.8f, 1f);
            jumpSound.pitch = Random.Range(.8f, 1.1f);
            jumpSound.Play();
        }
        jump = false;
    }
}
