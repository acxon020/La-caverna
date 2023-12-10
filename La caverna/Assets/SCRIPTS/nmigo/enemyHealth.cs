using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void TakeDamage (int amount)
    {
        currentHealth -= amount;
        if (currentHealth <=0)
        {
            Destroy(gameObject);
        }
    }
    
}
