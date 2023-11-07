using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    //esto aparece en script
    public CharacterController2D controller;
    public float Speed = 40f;

    
    //esto lo mandamos a llamar adentro del juego
    private Rigidbody2D rb2d; //gravedad
    float horizontalMove = 0f;//movimiento horizontal
    bool Jump= false;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //para que al inicio tenga gravedad

    }
    //codigo de salto, llamado una vez por cada frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")* Speed; //movimiento horizontal

        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;

        }

    }

        void FixedUpdate()
        //fisicas de movimiento
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, Jump);
            Jump = false;
        }
}