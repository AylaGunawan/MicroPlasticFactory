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
            manager.oilAmount += 1;
        }
        else if (manager.currentScreen == GameManagerScript.Screen.PRODUCTION)
        {
            manager.plasticAmount += 1;
        }
        else
        {
            manager.moneyAmount += 1; // temp, should be customers
        }

    }
}