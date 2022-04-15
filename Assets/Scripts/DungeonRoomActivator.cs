using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRoomActivator : MonoBehaviour
{
    public GameObject[] allEnemies;
    private List<GameObject> clonedEnemies = new List<GameObject>();

    public bool lockDoors;
    public GameObject[] doors;
    private bool doorsLocked,dontSpawnEnemies;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject enemy in allEnemies)
        {
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (doorsLocked)
        {
            bool enemyFound = false;
            for(int i = 0; i < clonedEnemies.Count; i++)
            {
                if (clonedEnemies[i]!=null)
                {
                    enemyFound = true;
                }
            }

            if (!enemyFound)
            {
                foreach(GameObject door in doors)
                {
                    door.SetActive(false);
                }
                doorsLocked = false;
                lockDoors = false;
                dontSpawnEnemies = true;
            }

        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.ToLower() == "player")
        {
            DungeonCameraController.instance.targetPoint=new Vector3(transform.position.x,transform.position.y,DungeonCameraController.instance.targetPoint.z);
            SpawnEnemies();

            if (lockDoors)
            {
                foreach(GameObject door in doors)
                {
                    door.SetActive(true);
                }
                doorsLocked = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (PlayerHealthController.instance.currentHealth > 0)
            {
                DespawnEnemies();
            }
        }
    }

    private void SpawnEnemies()
    {
        if (dontSpawnEnemies) { return; }
        foreach (GameObject enemy in allEnemies)
        {
            GameObject newEnemy = Instantiate(enemy, enemy.transform.position, enemy.transform.rotation);
            newEnemy.SetActive(true);
            clonedEnemies.Add(newEnemy);
        }
    }

    private void DespawnEnemies()
    {
        foreach (GameObject enemy in clonedEnemies)
        {
            Destroy(enemy);
        }

        clonedEnemies.Clear();
    }

}
