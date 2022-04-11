using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinValue;
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
        if(other.tag.ToLower() == "player")
        {
            GameManager.instance.GetCoin(coinValue);
            Destroy(gameObject);
            AudioManager.instance.PlaySFX(3);
        }
    }

}
