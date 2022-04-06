using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public float currentHealth;

    public GameObject deathEffect;

    private EnemyController theEC;
    // Start is called before the first frame update
    void Start()
    {
        theEC=GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            if(deathEffect != null)
            {
                Instantiate(deathEffect,transform.position,transform.rotation);
            }
            Destroy(gameObject);
        }
        theEC.knockBack(PlayerController.instance.transform.position);  
    }

}
