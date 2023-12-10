using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    private int Combocounter = 0;
    public float tiempoMaxCombo = 0.5f;
    private float LastHitTime;
    public Animator animator;

    // Referencia al script AtaqueColliding
    public AtaqueColliding ataqueColliding;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            Attack();
        }
    }


    void Attack()
    {
        if (Time.time - LastHitTime > tiempoMaxCombo)
        {
            Combocounter = 0; // Restablecer el combo si ha pasado demasiado tiempo entre golpes
        }

        Combocounter++;

        switch (Combocounter)
        {
            case 1:

                animator.SetTrigger("Attack1");
                break;

            case 2:

                animator.SetTrigger("Attack2");
                break;

            case 3:
            
                animator.SetTrigger("Attack3");
                // Resetea el contador de combo después del tercer golpe
                Combocounter = 0;
                break;

            default:
              animator.SetTrigger("Attack1");
                break;
        }

        LastHitTime = Time.time; // Actualiza el tiempo del último golpe
    }

}
