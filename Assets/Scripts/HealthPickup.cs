using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthToRestore = 30;

    public float lifeTime = 4f;

    private float waitToPickup = .5f;
    // Start is called before the first frame update
    void Start()
    {
        if (lifeTime > 0)
        {
            Destroy(gameObject, lifeTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (waitToPickup > 0)
        {
            waitToPickup-=Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.ToLower() == "player" && waitToPickup<=0)
        {
            PlayerHealthController.instance.RestoreHealth(healthToRestore);
            Destroy(gameObject);
            AudioManager.instance.PlaySFX(6);
        }
    }

}
