using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueColliding : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Hitbox")
        {
            collision.gameObject.GetComponent<enemyHealth>().TakeDamage(7);
        }
    }

    // Función para manejar la colisión desde el script Ataque
    public void HandleCollision()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

    }
}
