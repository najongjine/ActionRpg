using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthToRestore=30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.ToLower() == "player")
        {
            PlayerHealthController.instance.RestoreHealth(healthToRestore);
            Destroy(gameObject);
        }
    }

}
