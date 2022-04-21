using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public SaveData activeSave;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

[System.Serializable]
public class SaveData
{
    public bool hasBegun;
    public Vector3 sceneStartPosition;
    public string currentScene;
    public int maxHealth, currentSword, swordDamage, currentCoins;
    public float maxStamina;
}
