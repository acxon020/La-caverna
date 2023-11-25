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

        // Ataque si el enemigo está a una cierta distancia
        Atacar();
    }

    void MoverHorizontal()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(movimientoHorizontal * velocidadMovimiento * Time.deltaTime, 0, 0));
    }

    void Atacar()
    {
        // Obtener la posición del enemigo
        GameObject enemigo = GameObject.FindWithTag("Enemigo");
        if (enemigo != null)
        {
            float distanciaAlEnemigo = Vector3.Distance(transform.position, enemigo.transform.position);

            // Atacar si el enemigo está a una cierta distancia
            if (distanciaAlEnemigo <= rangoAtaque)
            {
                Debug.Log("Atacando al enemigo!");
                // Aquí puedes poner la lógica de ataque, como causar daño al enemigo, reproducir animaciones, etc.
            }
        }
    }
}
