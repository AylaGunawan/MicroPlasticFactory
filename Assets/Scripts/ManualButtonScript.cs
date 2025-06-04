using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualButtonScript : MonoBehaviour
{
    [SerializeField] GameObject GameManager;

    GameManagerScript manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddResource()
    {
        if (manager.currentScreen == GameManagerScript.Screen.EXTRACTION)
        {
            manager.AddOil(1); // temp, should add manual rate
        }
        else if (manager.currentScreen == GameManagerScript.Screen.PRODUCTION)
        {
            manager.AddPlastic(1); // temp, should add manual rate
        }
        else
        {
            manager.AddMoney(1); // temp, should be customers
        }

    }
}