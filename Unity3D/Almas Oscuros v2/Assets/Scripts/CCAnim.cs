using System.Collections;
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
        GroundedCheck();
        MoveCharacter();
        RotateCharacter();
    }

    public void RotateCharacter()
    {
        lookTarget.x = TempPos.x;
        lookTarget.z = TempPos.z;
        Anim.SetFloat("Turn Angle", Quaternion.Angle(this.transform.rotation, Quaternion.LookRotation(lookTarget, Vector3.up)));
        if (Vector3.Distance(Vector3.zero, lookTarget) > .2f)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(lookTarget, Vector3.up), .1f);
        }
    }

    public void MoveCharacter()
    {
        TempPos = new Vector3(Anim.GetFloat("Temp X"), 0f, Anim.GetFloat("Temp Z"));
        TempPos = camTransform.TransformDirection(TempPos);
        TempPos.y = Anim.GetFloat("Temp Y");
        CC.Move(TempPos * Time.deltaTime * playerSpeed);
    }

    void GroundedCheck() {
        Anim.SetBool("Grounded", CC.isGrounded);
    }
}
