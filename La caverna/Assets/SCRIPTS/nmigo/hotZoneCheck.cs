using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotZoneCheck : MonoBehaviour
{
    private Enemy_Behaviour enemyParent;
    private bool inRange;
    private Animator animator;

    private void Awake()
    {
        enemyParent = GetComponentInParent<Enemy_Behaviour>(); // Obtener la referencia al componente Enemy_Behaviour en el parent (Nmigo)
        animator = GetComponentInParent<Animator>(); // Obtener la referencia al Animator en el parent (Nmigo)
    }

    private void Update()
    {
        if (inRange && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            enemyParent.Flip(); // Voltear al enemigo si está en rango y no está atacando
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            inRange = true; // Indicar que el jugador está dentro del área de activación
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            inRange = false; // Indica que el jugador salió del área de activación
            gameObject.SetActive(false); // Desactiva la zona caliente
            enemyParent.triggerArea.SetActive(true); // Activa el área de activación para que el enemigo vuelva a perseguir al jugador
            enemyParent.inRange = false; // Indica que el jugador ya no está en rango del enemigo
            enemyParent.SelectTarget(); // Seleccionar un nuevo target para el enemigo
        }
    }
}