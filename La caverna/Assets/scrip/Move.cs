using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    //esto aparece en script
    public CharacterController2D controller;
    public Animator animator;
    public float Speed = 10f;

    
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

        animator.SetFloat ("Speed", Mathf.Abs(horizontalMove)); //el animador requiere de una velocidad
        //Y debido a que tiene que ser positiva, al presionar direccion izq, sería negativo. Para eso ayuda
        // "Math.Abs"

        if (Input.GetButtonDown("Jump")) //Se llama cuando se presiona el botón
        {
            Jump = true;
            animator.SetBool("IsJumping", true);

        }
        if (Input.GetButtonDown("Crouch")) // Se llama cuando se presiona el botón 
        {
            Crouch = true;
        } else if (Input.GetButtonUp("Crouch")) // La acción continúa hasta que se suelta el botón 
        {
            Crouch = false;
        }

    }

    public void OnLanding ()  //Aquí se crea una función que se conecta con el controlador y dice cuando dejar de saltar
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching (bool IsCrouching)
    {
        animator.SetBool("IsCrouching", IsCrouching);
    }
        void FixedUpdate()
        //fisicas de movimiento, esto se agrega para que sin importar la cantidad de veces q se presione el botón, el movimiento será fluido
        // Y si algún botón de movimiento no es presionado, entonces son falsos
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, Crouch, Jump);
            Jump = false;
        }
}