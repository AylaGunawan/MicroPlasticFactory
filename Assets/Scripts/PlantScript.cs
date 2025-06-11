using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    GameManagerScript manager;

    public float time = 1.0f; // in seconds
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindAnyObjectByType<GameManagerScript>();

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
            manager.AddPlastic(manager.GetPlasticPerPlant());
            timer = time;
        }
    }
}
