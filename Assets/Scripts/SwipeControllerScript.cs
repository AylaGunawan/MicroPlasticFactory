using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControllerScript : MonoBehaviour
{
    [SerializeField] GameObject GameManager;
    [SerializeField] GameObject RigGroup;
    [SerializeField] GameObject PlantGroup;
    [SerializeField] GameObject ShopGroup;
    [SerializeField] Camera Camera;

    GameManagerScript manager;

    Vector3 touchStart;
    Vector3 touchEnd;
    Vector3 touchLast;
    Vector3 camPos;

    public float swipeSpeed = 0.01f;
    public float swipeThreshold = 300f;
    public float screenCenterX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.GetComponent<GameManagerScript>();

        manager.currentScreen = GameManagerScript.Screen.EXTRACTION;

        screenCenterX = RigGroup.transform.position.x;
        camPos = new Vector3(screenCenterX, 0f, 0f);
        Camera.transform.position = camPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStart = new Vector3(touch.position.x, touch.position.y, 0f);
                touchLast = touchStart;
            }

            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 touchCurrent = new Vector3(touch.position.x, touch.position.y);
                Vector3 touchMove = touchCurrent - touchLast;

                // Convert screen delta to world movement
                float moveX = -touchMove.x * swipeSpeed;

                // Apply horizontal movement only
                camPos += new Vector3(moveX, 0f, 0f);
                Camera.transform.position = camPos;

                touchLast = touchCurrent;
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                touchEnd = touch.position;

                float touchXDiff = Mathf.Abs(touchEnd.x - touchStart.x);

                if (touchXDiff >= swipeThreshold)
                {
                    if (touchEnd.x < touchStart.x)
                    {
                        NextScreen();
                        
                    }

                    if (touchEnd.x > touchStart.x)
                    {
                        PrevScreen();
                        
                    }
                }
                else
                {
                    
                }

                camPos = new Vector3(screenCenterX, 0f, 0f);
                Camera.transform.position = camPos;
            }
        }
    }

    void NextScreen()
    {
        if (manager.currentScreen == GameManagerScript.Screen.EXTRACTION)
        {
            manager.currentScreen = GameManagerScript.Screen.PRODUCTION;
            screenCenterX = PlantGroup.transform.position.x;
        }

        else if (manager.currentScreen == GameManagerScript.Screen.PRODUCTION)
        {
            manager.currentScreen = GameManagerScript.Screen.DISTRIBUTION;
            screenCenterX = ShopGroup.transform.position.x;
        }
    }

    void PrevScreen()
    {
        if (manager.currentScreen == GameManagerScript.Screen.DISTRIBUTION)
        {
            manager.currentScreen = GameManagerScript.Screen.PRODUCTION;
            screenCenterX = PlantGroup.transform.position.x;
        }

        else if (manager.currentScreen == GameManagerScript.Screen.PRODUCTION)
        {
            manager.currentScreen = GameManagerScript.Screen.EXTRACTION;
            screenCenterX = RigGroup.transform.position.x;
        }
    }
}
