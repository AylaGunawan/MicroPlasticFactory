using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManagerScript : MonoBehaviour
{
    [SerializeField] GameObject GameManager;
    [SerializeField] GameObject plantPrefab;
    [SerializeField] Transform plantGroup;

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

    public void AddPlantInstance()
    {
        manager.AddPlant(1);
        GameObject p = Instantiate(plantPrefab, plantGroup);

        manager.UpdatePlasticRate();
    }
}
