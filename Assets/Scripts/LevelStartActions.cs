using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStartActions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.instance.DoatLevelStart();
        SaveManager.instance.activeSave.currentScene = SceneManager.GetActiveScene().name;
        SaveManager.instance.activeSave.sceneStartPosition=PlayerController.instance.transform.position;
        SaveManager.instance.saveInfo();
    }

    
}
