using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public string bossName;
    public int bossHealth;

    public GameObject theBoss, door1, door2;
    public Transform[] spawnPoints;
    private Vector3 moveTarget;
    public float moveSpeed;
    public float timeActive, timeBetweenSpawns, firstSpawnDelay;
    private float activeCounter, spawnCounter;

    public GameObject deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        door1.SetActive(true);
        door2.SetActive(true);
        spawnCounter = firstSpawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossHealth > 0)
        {
            if (spawnCounter > 0)
            {
                spawnCounter -= Time.deltaTime;
                if (spawnCounter <= 0)
                {
                    activeCounter = timeActive;
                    theBoss.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                    moveTarget = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                    theBoss.SetActive(true);
                }

            }
            else
            {
                activeCounter -= Time.deltaTime;
                if (activeCounter <= 0)
                {
                    spawnCounter = timeBetweenSpawns;
                    theBoss.SetActive(false);
                }
                theBoss.transform.position = Vector3.MoveTowards(theBoss.transform.position, moveTarget, moveSpeed * Time.deltaTime);

            }

        }

    }

    public void TakeDamage(int damageToTake)
    {
        bossHealth -= damageToTake;
        if(bossHealth <= 0)
        {
            bossHealth = 0;
            theBoss.SetActive(false);
            door1.SetActive(false);
            door2.SetActive(false);
            Instantiate(deathEffect,theBoss.transform.position, theBoss.transform.rotation);
        }

    }

}
