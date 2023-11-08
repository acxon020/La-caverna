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
    bool Jump= false; //salto 
    bool Crouch = false; // agacharse
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //para que al inicio tenga gravedad

    }
    //codigo de movimiento, llamado una vez por cada frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")* Speed; //movimiento horizontal

        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;

        }
        if (Input.GetButtonDown("Crouch"))
        {
            Crouch = true;
        }

    }

        void FixedUpdate()
        //fisicas de movimiento, esto se agrega para que sin importar la cantidad de veces q se presione el botón, el movimiento será fluido
        // Y si algún botón de movimiento no es presionado, entonces son falsos
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, Crouch, Jump);
            Jump = false;
            Crouch = false;
        }
}