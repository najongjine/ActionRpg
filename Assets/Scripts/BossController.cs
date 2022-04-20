using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public string bossName;
    public int bossHealth;
    public int stage2Threshold, stage3Threshold;

    public GameObject theBoss, door1, door2;
    public Transform[] spawnPoints;
    private Vector3 moveTarget;
    public float moveSpeed;
    public float timeActive, timeBetweenSpawns, firstSpawnDelay;
    private float activeCounter, spawnCounter;

    public GameObject deathEffect;

    public BossShot theShot;
    public Transform[] shotPoints;
    public Transform shotCenter;
    public float timeBetweenShots,shotRotateSpeed;
    private float shotCounter;

    public AudioSource levelBGM, bossBGM;

    public GameObject victoryObject;
    // Start is called before the first frame update
    void Start()
    {
        door1.SetActive(true);
        door2.SetActive(true);
        spawnCounter = firstSpawnDelay;
        UIManager.instance.bossHealthSlider.maxValue = bossHealth;
        UIManager.instance.bossHealthSlider.value = bossHealth;
        UIManager.instance.bossHealthSlider.gameObject.SetActive(true);

        UIManager.instance.bossNameText.text = bossName;
        UIManager.instance.bossNameText.gameObject.SetActive(true);
        levelBGM.Stop();
        bossBGM.Play();
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

                shotCounter-=Time.deltaTime;
                if (shotCounter <= 0)
                {
                    shotCounter = timeBetweenShots;
                    if (bossHealth >= stage2Threshold)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            Instantiate(theShot, shotPoints[i].position, shotPoints[i].rotation).SetDirection(shotCenter.position);
                        }
                    }
                    else{
                        for (int i = 0; i < shotPoints.Length; i++)
                        {
                            Instantiate(theShot, shotPoints[i].position, shotPoints[i].rotation).SetDirection(shotCenter.position);
                        }

                    }
                    
                }
                if (bossHealth <= stage3Threshold)
                {
                    shotCenter.transform.rotation = Quaternion.Euler(shotCenter.transform.rotation.eulerAngles.x, shotCenter.transform.rotation.eulerAngles.y, shotCenter.transform.rotation.eulerAngles.z + (shotRotateSpeed * Time.deltaTime));
                }

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
            //door1.SetActive(false);
            //door2.SetActive(false);
            Instantiate(deathEffect,theBoss.transform.position, theBoss.transform.rotation);

            UIManager.instance.bossHealthSlider.gameObject.SetActive(false);
            UIManager.instance.bossNameText.gameObject.SetActive(false);
            levelBGM.Play();
            bossBGM.Stop();

            victoryObject.SetActive(true);
        }
        UIManager.instance.bossHealthSlider.value = bossHealth;

    }

}
