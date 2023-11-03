using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    //esto aparece en script
    public float Speed;
    public float JumpForce;

    //esto lo mandamos a llamar adentro del juego
    private Rigidbody2D rb2d; //gravedad
    private float Horizontal;//movimiento horizontal
    private bool Grounded; //piso

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //para que al inicio tenga gravedad

    }
    //codigo de salto
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal"); //movimiento horizontal

        Debug.DrawRay(transform.position, Vector3.down * 1.0f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;

        }
        else
        {
            Grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.W) && Grounded) // brinco
        {
            rb2d.AddForce(Vector2.up * JumpForce);
        }
    }

    private void FixedUpdate()
    //fisicas de movimiento
    {
        rb2d.velocity = new Vector2(Horizontal * Speed, rb2d.velocity.y);
    }
}