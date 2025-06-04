using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigScript : MonoBehaviour
{
    GameManagerScript manager;

    public float time = 1.0f; // in seconds
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindAnyObjectByType<GameManagerScript>();
        if (manager != null)
        {
            Debug.Log("yippee");
        }

        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            manager.AddOil(manager.GetOilPerRig());
            timer = time;
        }
    }
}
