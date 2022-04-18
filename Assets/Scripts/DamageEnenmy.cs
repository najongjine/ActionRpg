using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnenmy : MonoBehaviour
{
    public int damageToDeal;

    public GameObject hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnHitEffect()
    {
        Instantiate(hitEffect, transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.ToLower() == "enemy")
        {
            other.GetComponent<EnemyHealthController>().TakeDamage(damageToDeal);
            SpawnHitEffect();
        }
        if(other.tag.ToLower() == "breakable")
        {
            other.GetComponent<BreakableObject>().Break();
            SpawnHitEffect();
        }
        if (other.tag.ToLower() == "boss")
        {
            other.GetComponent<BossWeakpoint>().DamageBoss(damageToDeal);
            SpawnHitEffect();
        }
    }

}
