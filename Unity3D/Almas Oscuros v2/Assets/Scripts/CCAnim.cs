﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCAnim : MonoBehaviour {

    private CharacterController CC;

    private Animator Anim;

    private Vector3 TempPos;
    private Vector3 lookTarget;
    public float playerSpeed;

    public Transform camTransform;

    void Start()
    {
        CC = GetComponent<CharacterController>();
        Anim = GetComponentInChildren<Animator>();
    }

    void Update() {
        MoveCharacter();
        RotateCharacter();
    }

    public void RotateCharacter()
    {
        lookTarget.x = TempPos.x;
        lookTarget.z = TempPos.z;
        if (Vector3.Distance(Vector3.zero, lookTarget) > .2f)
        {
            this.transform.rotation = Quaternion.LookRotation(lookTarget, Vector3.up);
        }
    }

    public void MoveCharacter()
    {
        TempPos = new Vector3(Anim.GetFloat("Temp X"), Anim.GetFloat("Temp Y"), Anim.GetFloat("Temp Z"));
        TempPos = camTransform.TransformDirection(TempPos);
        CC.Move(TempPos * Time.deltaTime * playerSpeed);
        RotateCharacter();
    }

    void GroundedCheck() {
        Anim.SetBool("Grounded", CC.isGrounded);
    }
}
