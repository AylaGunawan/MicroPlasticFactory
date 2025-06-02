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

    public float oilRate;
    public float plasticRate;
    public float moneyRate;

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

        rigCount = 0;
        plantCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        OilText.text = oilAmount.ToString();
        PlasticText.text = plasticAmount.ToString();
        MoneyText.text = moneyAmount.ToString();

        OilRateText.text = oilRate.ToString() + "/s";
        PlasticRateText.text = plasticRate.ToString() + "/s";
        MoneyRateText.text = moneyRate.ToString() + "/s";
    }
}