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
            Die();
        }
    }

    void UpdateUI()
    {
        float healthPercent =
            currentHealth / maxHealth;

        healthBarFill.fillAmount = healthPercent;

        healthText.text =
            Mathf.Round(currentHealth)
            + " / "
            + Mathf.Round(maxHealth);
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}