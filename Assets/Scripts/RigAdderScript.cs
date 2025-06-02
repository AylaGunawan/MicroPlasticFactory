using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigAdderScript : MonoBehaviour
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

    public void AddRig()
    {
        manager.rigCount += 1;
    }
}
