using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public Animator anim;

    public void TakeDamage(float _damage)
    {
        anim.SetFloat("Health", anim.GetFloat("Health") - _damage);
        anim.SetTrigger("Injury");
    }

}
