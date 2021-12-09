using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHouse : MonoBehaviour
{
    public GameObject blueprint;
    public ResourceManager ResourceManager;

    public void SpawnBlueprint()
    {
        if (!GameObject.FindGameObjectWithTag("Blueprint") 
            && ResourceManager.stoneQ >= 25
            && ResourceManager.steelQ >= 25)
        {
            Instantiate(blueprint);
            ResourceManager.stoneQ -= 25;
            ResourceManager.steelQ -= 25;
        }
    }
}
