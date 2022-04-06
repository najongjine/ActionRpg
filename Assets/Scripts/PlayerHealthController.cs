using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth;
    public int maxHealth;

    public float invincibilityLength = 1f;
    private float invCounter;

    public GameObject deathEffect;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (invCounter > 0)
        {
            invCounter -= Time.deltaTime;
        }

    }

    public void DamagePlayer(int damageAmount)
    {
        if (invCounter <= 0)
        {
            currentHealth -= damageAmount;
            invCounter = invincibilityLength;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                gameObject.SetActive(false);
                Instantiate(deathEffect,transform.position,transform.rotation);
            }

        }

    }

}