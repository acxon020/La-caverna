using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{
    #region Public variables
    public float attackDistance; // Distancia mínima de ataque
    public float moveSpeed;
    public float timer; // Temporizador entre ataques
    public LayerMask walkableLayer;
    public Transform leftLimit;
    public Transform rightLimit;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange; // Verificar si el jugador está en rango
    public GameObject hotZone;
    public GameObject triggerArea;
    #endregion

    #region Private Variables
    private Animator animator;
    private float distance; // Almacen la distancia entre enemigo y jugador
    private bool attackMode;
    private bool cooling; // Verifica si el enemigo se "enfría" después de atacar
    private float intTimer;
    #endregion

    void Awake()
    {
        SelectTarget();
        intTimer = timer; // Almacena el valor inicial del contador
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!attackMode)
        {
            Move(); // se mueve si no está en modo de ataque
        }
        if (!insideoflimits() && !inRange && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            SelectTarget(); // Selecciona un nuevo objetivo si está fuera de los límites y no está atacando
        } 

         RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, walkableLayer);

        if (hit.collider != null)
        {
            // El objeto está en la capa "walkable"
            Move(); // Moverse en la dirección actual
        }

        if (inRange)
        {
            EnemyLogic(); // LLama a la Lógica del enemigo cuando está en rango
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            StopAttack(); // Detiene el ataque si la distancia es mayor que la distancia de ataque
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack(); // Ataca si la distancia es menor o igual a la distancia de ataque y no está en enfriamiento
        }
        if (cooling)
        {
            Cooldown(); // el ememigo se enfría después del ataque
            animator.SetBool("Attack", false);
        }
    }

    void Move()
    {
        animator.SetBool("canWalk", true);

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && target != null)
        {
            // El enemigo se mueve hacia el objetivo si no está atacando y hay un objetivo
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer; // Reiniciar contador cuando el jugador entra en rango de ataque
        attackMode = true; // Para verificar si el enemigo aún puede atacar o no
        animator.SetBool("canWalk", false);
        animator.SetBool("Attack", true);
    }

    void Cooldown() //función de "enfriamiento"
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }
    
    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        animator.SetBool("Attack", false);
        animator.SetBool("canWalk", true);
    }

    public void TriggerCooling()
    {
        cooling = true; // Activar el enfriamiento después de un ataque
    }

    private bool insideoflimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    public void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);
        
        if (distanceToLeft > distanceToRight)
        {
            target = leftLimit; // Selecciona el límite izquierdo como objetivo
        }
        else
        {
            target = rightLimit; // Seleccionarel límite derecho como objetivo
        }
        if (target != null)
        {
        Flip();
        }

    }

    public void Flip ()
    {
        Vector3 rotation = transform.eulerAngles;
        if(transform.position.x > target.position.x)
        {
            rotation.y = 180f; // Gira 180 grados si el objetivo está a la izquierda
        }
        else
        {
            rotation.y = 0f; // No gira si el objetivo está a la derecha
        }

        transform.eulerAngles = rotation; // Aplica la rotación
    }
}