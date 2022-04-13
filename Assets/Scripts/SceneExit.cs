using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
    public string sceneToLoad;
    public Vector3 exitLocation;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.ToLower() == "player")
        {
            PlayerController.instance.transform.position = exitLocation;
            SceneManager.LoadScene(sceneToLoad);
        }

    }

}
