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

    [Header("Rate Variables")]

    public float oilRateVal;
    public float plasticRateVal;
    public float moneyRateVal;
    // customer rate

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

    [Header("Manual Variables")]

    public float oilManualVal;
    public float plasticManualVal;

    [Space]

    public float oilManualPercent;
    public float plasticManualPercent;

    [Space]

    public float oilManualMult;
    public float plasticManualMult;

    [Space]

    public float oilManualTotal;
    public float plasticManualTotal;

    [Header("Facility Variables")]

    public int rigCount;
    public int plantCount;
    //public int permitCount;

    void Awake()
    {
        OilText = OilTextObj.GetComponent<TMP_Text>();
        PlasticText = PlasticTextObj.GetComponent<TMP_Text>();
        MoneyText = MoneyTextObj.GetComponent<TMP_Text>();

        OilRateText = OilRateTextObj.GetComponent<TMP_Text>();
        PlasticRateText = PlasticRateTextObj.GetComponent<TMP_Text>();
        MoneyRateText = MoneyRateTextObj.GetComponent<TMP_Text>();

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

        oilManualVal = 1.0f;
        plasticManualVal = 1.0f;

        oilManualPercent = 0.0f;
        plasticManualPercent = 0.0f;

        oilManualMult = 1.0f;
        plasticManualMult = 1.0f;

        UpdateOilManual();
        UpdatePlasticManual();

        rigCount = 0;
        plantCount = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentScreen = Screen.EXTRACTION;
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
        oilRateTotal = GetOilPerRig() * rigCount;
    }

    public void UpdatePlasticRate()
    {
        plasticRateTotal = GetPlasticPerPlant() * plantCount;
    }

    public void UpdateOilManual()
    {
        oilManualTotal = GetOilManual();
    }

    public void UpdatePlasticManual()
    {
        plasticManualTotal = GetPlasticManual();
    }

    public float GetOilPerRig()
    {
        return (oilRateVal + (oilRateVal * oilRatePercent)) * oilRateMult;
    }

    public float GetPlasticPerPlant()
    {
        return (plasticRateVal + (plasticRateVal * plasticRatePercent)) * plasticRateMult;
    }

    public float GetOilManual()
    {
        return (oilManualVal + (oilManualVal * oilManualPercent)) * oilManualMult;
    }

    public float GetPlasticManual()
    {
        return (plasticManualVal + (plasticManualVal * plasticManualPercent)) * plasticManualMult;
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