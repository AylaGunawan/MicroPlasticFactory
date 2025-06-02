using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControllerScript : MonoBehaviour
{
    [SerializeField] GameObject GameManager;

    GameManagerScript manager;

    Vector2 startPos;
    Vector2 endPos;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startPos = Input.GetTouch(0).position;
            Debug.Log("start=" + Input.GetTouch(0).position.ToString());
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endPos = Input.GetTouch(0).position;
            Debug.Log("end=" + Input.GetTouch(0).position.ToString());

            if (endPos.x < startPos.x)
            {
                NextScreen();
            }

            if (endPos.x > startPos.x)
            {
                PrevScreen();
            }
        }
    }

    void NextScreen()
    {
        if (manager.currentScreen == GameManagerScript.Screen.EXTRACTION)
        {
            manager.currentScreen = GameManagerScript.Screen.PRODUCTION;
        }

        else if (manager.currentScreen == GameManagerScript.Screen.PRODUCTION)
        {
            manager.currentScreen = GameManagerScript.Screen.DISTRIBUTION;
        }
    }

    void PrevScreen()
    {
        if (manager.currentScreen == GameManagerScript.Screen.DISTRIBUTION)
        {
            manager.currentScreen = GameManagerScript.Screen.PRODUCTION;
        }

        else if (manager.currentScreen == GameManagerScript.Screen.PRODUCTION)
        {
            manager.currentScreen = GameManagerScript.Screen.EXTRACTION;
        }
    }
}
