using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    private Enemy_Behaviour enemyParent;

    private void Awake()
    {
        enemyParent = GetComponentInParent<Enemy_Behaviour>(); // Obtener la referencia al componente Enemy_Behaviour en el parent (Nmigo)
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false); // Desactivar el área de activación al entrar en contacto con el jugador
            enemyParent.target = collider.transform; // Establece sl jugador como target del enemigo
            enemyParent.inRange = true; // Indica que el jugador está dentro del rango del enemigo
            enemyParent.hotZone.SetActive(true); // Activa la hot zone para iniciar el ataque enemigo
        }
    }
}