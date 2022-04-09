using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Slider healthSlider, staminaSlider;
    public TMP_Text healthText, staminaText, coinsText;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
        UpdateStamina();
        UpdateCoins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth()
    {
        healthSlider.maxValue = PlayerHealthController.instance.maxHealth;
        healthSlider.value = PlayerHealthController.instance.currentHealth;
        healthText.text = $"Health : {PlayerHealthController.instance.currentHealth} / {PlayerHealthController.instance.maxHealth}";
    }
    public void UpdateStamina()
    {
        staminaSlider.maxValue = PlayerController.instance.totalStamina;
        staminaSlider.value = PlayerController.instance.currentStamina;
        staminaText.text= $"Stamina : {Mathf.RoundToInt(PlayerController.instance.currentStamina)} / {Mathf.RoundToInt(PlayerController.instance.totalStamina)}";
    }
    public void UpdateCoins()
    {
        coinsText.text = $"Coins : {GameManager.instance.currentCoins}";
    }

}
