using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthExample : MonoBehaviour
{

    private float health = 100;
    public Image BarraDeVida;
    [SerializeField]
    private float maxHealth = 100;

    // Used when starving and/or dehydrated
    [SerializeField]
    private float healthDecreaseDelay = 1.0f;
    [SerializeField]
    private float healthDecreaseAmount = 3.0f;
    public float HealthDecreaseAmount { get { return healthDecreaseAmount * (hungerThirst.IsStarving && hungerThirst.IsDehydrated ? 2 : 1); } }
    private float nextHealthDecrease = 0.0f;

    [Header("UI")]
    [SerializeField]
    private Text healthLbl;

    // References
    private HungerThirst hungerThirst;

    void Awake()
    {
        hungerThirst = FindObjectOfType<HungerThirst>();
        health = maxHealth;

        RefreshHUD();
    }

    void Update()
    {
        health = Mathf.Clamp(health, 0, 100);
        BarraDeVida.fillAmount = health / 100;

        if (hungerThirst.IsStarving || hungerThirst.IsDehydrated)
        {
            if (nextHealthDecrease <= Time.time)
            {
                SubHealth(HealthDecreaseAmount);
                nextHealthDecrease = Time.time + healthDecreaseDelay;
            }
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void SetHealth(float newHealth)
    {
        health = Mathf.Clamp(newHealth, 0, maxHealth);
        RefreshHUD();
    }
    public void AddHealth(float amount)
    {
        SetHealth(health + amount);
    }
    public void SubHealth(float amount)
    {
        SetHealth(health - amount);
    }

    private void RefreshHUD()
    {
        if (healthLbl == null)
        {
            Debug.Log("Health: " + health);
            return;
        }

        healthLbl.text = health.ToString();
    }
}