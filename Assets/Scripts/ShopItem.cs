using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [TextArea]
    public string description;
    public int itemCost;
    private bool itemActive;

    public bool isHealthUpgrade, isStaminaUpgrade;
    public int amountToAdd;

    public bool removeAfterPurchase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (itemActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (GameManager.instance.currentCoins>=itemCost)
                {
                    GameManager.instance.currentCoins-=itemCost;
                    UIManager.instance.UpdateCoins();
                    if (isHealthUpgrade)
                    {
                        PlayerHealthController.instance.maxHealth += amountToAdd;
                        PlayerHealthController.instance.currentHealth += amountToAdd;
                        SaveManager.instance.activeSave.maxHealth = PlayerHealthController.instance.maxHealth;
                        UIManager.instance.UpdateHealth();
                    }else if (isStaminaUpgrade)
                    {
                        PlayerController.instance.totalStamina += amountToAdd;
                        PlayerController.instance.currentStamina += amountToAdd;
                        SaveManager.instance.activeSave.maxStamina = PlayerController.instance.totalStamina;
                        UIManager.instance.UpdateStamina();
                    }

                    SaveManager.instance.activeSave.currentCoins=GameManager.instance.currentCoins;

                    if (removeAfterPurchase)
                    {
                        gameObject.SetActive(false);
                    }
                    DialogManager.instance.dialogBox.SetActive(false);
                    itemActive = false;

                }
                else
                {
                    DialogManager.instance.dialogText.text = $"You don't have Enough Coins!";
                }

            }

        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.ToLower() == "player")
        {
            itemActive = true;
            DialogManager.instance.dialogBox.SetActive(true);
            DialogManager.instance.dialogText.text = description;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.ToLower() == "player")
        {
            itemActive = true;
            DialogManager.instance.dialogBox.SetActive(false);
        }
    }
}
