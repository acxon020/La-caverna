using System.Collections;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public Animator animator;

    public SpriteRenderer playerSr;
    public Move PlayerMovement;
    #region
    private bool IsHurt = false;
    private bool IsDying = false;
    private float hurtAnimationDuration = 0.200f;
    private float DyingAnimationDuration = 1f;
    #endregion
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (IsHurt)
        {
            StartCoroutine(ResetHurtFlag());
        }

        if (IsDying)
        {
            StartCoroutine(ResetDyingFlag());
        }
    }

    IEnumerator ResetHurtFlag()
    {
        yield return new WaitForSeconds(hurtAnimationDuration);
        animator.SetBool("IsHurt", false);
        IsHurt = false;
    }

    IEnumerator ResetDyingFlag()
    {
        yield return new WaitForSeconds(DyingAnimationDuration);
        animator.SetBool("IsDying", false);
        IsDying = false;
        playerSr.enabled = false;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        // Reproducir animación de herida si el personaje está herido
        if (!IsHurt && health > 0)
        {
            animator.SetBool("IsHurt", true);
            IsHurt = true;
        }

        // Reproducir animación de morir si la salud es igual o menor a cero
        if (health <= 0 && !IsDying)
        {
            animator.SetBool("IsDying", true);
            IsDying = true;
            PlayerMovement.enabled = false;
        }
    }
}
