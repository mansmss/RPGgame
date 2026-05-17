using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;

    private float currentHealth;

    public Image healthBarFill;

    public TextMeshProUGUI healthText;

    void Start()
    {
        currentHealth = maxHealth;

        UpdateUI();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateUI();

        if (currentHealth <= 0)
        {
            Debug.Log("Player Dead");
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        healthBarFill.fillAmount =
            currentHealth / maxHealth;

        healthText.text =
            currentHealth + " / " + maxHealth;
    }
}