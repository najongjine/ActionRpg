using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordUnlock : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;

    public int newSwordDamage,swordSpriteRef;

    public string[] pickupDialog;

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
            gameObject.SetActive(false);
            if(door1 != null && door2 != null)
            {
                door1.SetActive(false);
                door2.SetActive(false);
            }
            PlayerController.instance.UpgradeSword(newSwordDamage, swordSpriteRef);

            if(pickupDialog.Length > 0)
            {
                DialogManager.instance.ShowDialog(pickupDialog,false);
            }

        }
    }

}
