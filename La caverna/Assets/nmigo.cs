using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nmigo : MonoBehaviour
{
    public float velocidadMovimiento;
    public float rangoAtaque;

    private void Update()
    {
        // Movimiento horizontal
        MoverHorizontal();

        // Ataque si el enemigo est� a una cierta distancia
        Atacar();
    }

    void MoverHorizontal()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(movimientoHorizontal * velocidadMovimiento * Time.deltaTime, 0, 0));
    }

    void Atacar()
    {
        // Obtener la posici�n del enemigo
        GameObject enemigo = GameObject.FindWithTag("Enemigo");
        if (enemigo != null)
        {
            float distanciaAlEnemigo = Vector3.Distance(transform.position, enemigo.transform.position);

            // Atacar si el enemigo est� a una cierta distancia
            if (distanciaAlEnemigo <= rangoAtaque)
            {
                Debug.Log("Atacando al enemigo!");
                // Aqu� puedes poner la l�gica de ataque, como causar da�o al enemigo, reproducir animaciones, etc.
            }
        }
    }
}
