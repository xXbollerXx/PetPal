using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClickerManager : MonoBehaviour
{
    public static AutoClickerManager Instance;

    public float ClickDelay = 1f;
    private float NextClick;
    float ClickValue { get => animalTap.Instance.singleTapIncrease; }
    public int AutoClickerAmount = 0;
    private float CPS;
    // Start is called before the first frame update
    private void Start()
    {
        NextClick = ClickDelay;
        if (!Instance)
        {
            Instance = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        NextClick -= Time.deltaTime;

        if(NextClick <= 0)
        {
            AutoClicker();
        }
        // if(NextClick <= Time.time)
        // {
        //     NextClick = Time.time + ClickDelay * Time.deltaTime;
        //     //fire click 
        //     float Temp = ClickValue * CPS;
        //     CurrencyManager.Instance.AddCurrency(Temp);
        // }

    }

    public void AddNewAutoClicker(float ClickPerSecondValue)
    {
        CPS += ClickPerSecondValue;
    }

    public void AutoClicker()
    {
        float Temp = ClickValue * CPS;
        CurrencyManager.Instance.AddCurrency(Temp);
        NextClick = ClickDelay;

    }
}
