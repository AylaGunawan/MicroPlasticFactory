using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public enum Screen
    {
        EXTRACTION = 0, PRODUCTION = 1, DISTRIBUTION = 2
    }

    [Header("UI References")]

    [SerializeField] GameObject OilTextObj;
    [SerializeField] GameObject PlasticTextObj;
    [SerializeField] GameObject MoneyTextObj;

    [Space]

    [SerializeField] GameObject OilRateTextObj;
    [SerializeField] GameObject PlasticRateTextObj;
    [SerializeField] GameObject MoneyRateTextObj;

    TMP_Text OilText;
    TMP_Text PlasticText;
    TMP_Text MoneyText;

    TMP_Text OilRateText;
    TMP_Text PlasticRateText;
    TMP_Text MoneyRateText;

    public Screen currentScreen;

    [Header("Resource Variables")]

    public float oilAmount;
    public float plasticAmount;
    public float moneyAmount;

    [Space]

    public float oilRateVal;
    public float plasticRateVal;
    public float moneyRateVal;

    [Space]

    public float oilRatePercent;
    public float plasticRatePercent;
    public float moneyRatePercent;

    [Space]

    public float oilRateMult;
    public float plasticRateMult;
    public float moneyRateMult;

    [Space]

    public float oilRateTotal;
    public float plasticRateTotal;
    public float moneyRateTotal;

    [Header("Facility Variables")]

    public int rigCount;
    public int plantCount;
    //public int permitCount;

    // Start is called before the first frame update
    void Start()
    {
        OilText = OilTextObj.GetComponent<TMP_Text>();
        PlasticText = PlasticTextObj.GetComponent<TMP_Text>();
        MoneyText = MoneyTextObj.GetComponent<TMP_Text>();

        OilRateText = OilRateTextObj.GetComponent<TMP_Text>();
        PlasticRateText = PlasticRateTextObj.GetComponent<TMP_Text>();
        MoneyRateText = MoneyRateTextObj.GetComponent<TMP_Text>();

        currentScreen = Screen.EXTRACTION;

        oilAmount = 0.0f;
        plasticAmount = 0.0f;
        moneyAmount = 0.0f;

        oilRateVal = 1.0f;
        plasticRateVal = 1.0f;
        moneyRateVal = 1.0f;

        oilRatePercent = 0.0f;
        plasticRatePercent = 0.0f;
        moneyRatePercent = 0.0f;

        oilRateMult = 1.0f;
        plasticRateMult = 1.0f;
        moneyRateMult = 1.0f;

        UpdateOilRate();
        UpdatePlasticRate();
        moneyRateTotal = 0.0f;

        rigCount = 0;
        plantCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        OilText.text = oilAmount.ToString();
        PlasticText.text = plasticAmount.ToString();
        MoneyText.text = moneyAmount.ToString();

        OilRateText.text = oilRateTotal.ToString() + "/s";
        PlasticRateText.text = plasticRateTotal.ToString() + "/s";
        MoneyRateText.text = moneyRateTotal.ToString() + "/s";
    }

    public void UpdateOilRate()
    {
        oilRateTotal = ((oilRateVal + (oilRateVal * oilRatePercent)) * rigCount) * oilRateMult;
    }

    public void UpdatePlasticRate()
    {
        plasticRateTotal = ((plasticRateVal + (plasticRateVal * plasticRatePercent)) * plantCount) * plasticRateMult; // mult at end?
    }

    public float GetOilPerRig()
    {
        return plasticRateVal + (plasticRateVal * plasticRatePercent);
    }

    public void AddOil(float val)
    {
        oilAmount += val;
    }

    public void AddPlastic(float val)
    {
        plasticAmount += val;
    }

    public void AddMoney(float val)
    {
        moneyAmount += val;
    }

    public void AddRig(int val)
    {
        rigCount += val;
    }

    public void AddPlant(int val)
    {
        plantCount += val;
    }
}