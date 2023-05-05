using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerThirst : MonoBehaviour
{
    public Image BarraDeHunger;
    public Image BarraDeThirst;
    [Header("Core - Hunger")]
    [Tooltip("How long till next hunger increase")]
    [SerializeField]
    private float hungerIncreaseDelay = 5.0f; public float HungerIncreaseDelay { get { return hungerIncreaseDelay; } }
    [Tooltip("How much the hunger should increase after every delay")]
    [SerializeField]
    private float hungerIncreaseAmount = 8.0f;
    [Tooltip("How much hunger has to be before health begins to slowly decrease")]
    [SerializeField]
    private float hungerMax = 100.0f;
    public float Hunger  { get; private set; }= 100;
    public bool IsStarving { get; private set; }
    private float nextHungerIncrease = 0.0f;


    [Header("Core - Thirst")]
    [Tooltip("How long till next thirst increase")]
    [SerializeField]
    private float thirstIncreaseDelay = 3.0f; public float ThirstIncreaseDelay { get { return thirstIncreaseDelay; } }
    [Tooltip("How much the thirst should increase after every delay")]
    [SerializeField]
    private float thirstIncreaseAmount = 12.0f;
    [Tooltip("How much thirst has to be before health begins to slowly decrease")]
    [SerializeField]
    private float thirstMax = 100.0f;
    public float Thirst  { get; private set; } = 100;
    public bool IsDehydrated { get; private set; }
    private float nextThirstIncrease = 0.0f;



    [Header("UI")]
    [SerializeField]
    private Text hungerLbl;
    [SerializeField]
    private Text thirstLbl;
    void Awake()
    {
        Hunger = hungerMax;
        Thirst = thirstMax;
    }
    void Start()
    {
        RefreshHUD();
    }
    void Update()
    {
        Hunger = Mathf.Clamp(Hunger, 0, 100);
        BarraDeHunger.fillAmount = Hunger / 100;

        Thirst = Mathf.Clamp(Thirst, 0, 100);
        BarraDeThirst.fillAmount = Thirst / 100;



        if (nextHungerIncrease <= Time.time)
        {
            AddHunger(hungerIncreaseAmount);
            nextHungerIncrease = Time.time + hungerIncreaseDelay;
        }

        if (nextThirstIncrease <= Time.time)
        {
            AddThirst(thirstIncreaseAmount);
            nextThirstIncrease = Time.time + thirstIncreaseDelay;
        }
    }

    /*============================
     * HUNGER
     *============================*/
    private void SetHunger(float newHunger)
    {
        Hunger = Mathf.Clamp(newHunger, 0, hungerMax);
        IsStarving = (Hunger >= hungerMax - 0.01f) ? true : false;
        
        RefreshHUD();
    }
    public void AddHunger(float amount)
    {
        SetHunger(Hunger - amount);
    }
    public void SubHunger(float amount)
    {
        SetHunger(Hunger - amount);
    }

    /*============================
     * THIRST
     *============================*/
    private void SetThirst(float newThirst)
    {
        Thirst = Mathf.Clamp(newThirst, 0, thirstMax);
        IsDehydrated = (Thirst >= thirstMax - 0.01f) ? true : false;

        RefreshHUD();
    }
    public void AddThirst(float amount)
    {
        SetThirst(Thirst - amount);
    }
    public void SubThirst(float amount)
    {
        SetThirst(Thirst - amount);
    }


    /*============================
     * UI
     *============================*/
    private void RefreshHUD()
    {
        if (hungerLbl == null || thirstLbl == null)
        {
            Debug.Log(string.Format("Hunger: {0}", Hunger));
            Debug.Log(string.Format("Thirst: {0}", Thirst));
            return;
        }

        hungerLbl.text = string.Format("Hunger: {0}", Hunger);
        thirstLbl.text = string.Format("Thirst: {0}", Thirst);
    }
}