using UnityEngine;

public class BuildWorkshop : MonoBehaviour
{
    public GameObject blueprint;
    public ResourceManager ResourceManager;

    public void SpawnBlueprint()
    {
        if (!GameObject.FindGameObjectWithTag("Blueprint")
            && ResourceManager.steelQ >= 50
            && ResourceManager.fuelQ >= 5)
        {
            Instantiate(blueprint);
            ResourceManager.steelQ -= 50;
            ResourceManager.fuelQ -= 5;
        }
    }

}
