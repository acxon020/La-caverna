using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        
        Attack ();
    }

    void Attack ()
    {
    animator.SetTrigger("Attack");
    }


}
