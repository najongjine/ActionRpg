using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
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
        //Debug.Log(Application.persistentDataPath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadInfo()
    {

    }
    public void saveInfo()
    {
        string dataPath = Application.persistentDataPath;

        var serializer=new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(dataPath + "/save.data",FileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();

        Debug.Log("Data Saved");
    }
    private void OnApplicationQuit()
    {
        saveInfo();
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
