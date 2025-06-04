using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigManagerScript : MonoBehaviour
{
    [SerializeField] GameObject GameManager;
    [SerializeField] GameObject rigPrefab;
    [SerializeField] Transform rigGroup;

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

    public void AddRig()
    {
        manager.AddRig(1);
        GameObject r = Instantiate(rigPrefab);
        r.transform.SetParent(rigGroup.transform);

        manager.UpdateOilRate();
    }
}
