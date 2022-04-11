using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public float currentHealth;

    public GameObject deathEffect;

    private EnemyController theEC;

    public GameObject healthToDrop, coinToDrop;
    public float healthDropChance, coinDropChance;
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
            if (healthToDrop!=null && Random.Range(0f,100f)<healthDropChance)
            {
                Instantiate(healthToDrop,transform.position,transform.rotation);
            }
            if (coinToDrop != null && Random.Range(0f, 100f) < coinDropChance)
            {
                Instantiate(coinToDrop, transform.position, transform.rotation);
            }
            AudioManager.instance.PlaySFX(4);

        }
        AudioManager.instance.PlaySFX(7);
        theEC.knockBack(PlayerController.instance.transform.position);  
    }

}
