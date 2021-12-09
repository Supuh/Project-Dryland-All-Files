using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public Text stoneText;
    public Text steelText;
    public Text fuelText;

    public int stoneQ;
    public int steelQ;
    public int fuelQ;

    public void ResourceGather(string source, int resourceToAdd)
    {
        for (int i = 0; i < resourceToAdd; i++)
        {
            if (source.Equals("stone"))
            {
                stoneQ++;
            }
            else if (source.Equals("steel"))
            {
                steelQ++;
            }
            else if (source.Equals("fuel"))
            {
                fuelQ++;
            }
            else
            {
                break;
            }
        }

        stoneText.text = stoneQ + " - Stone";
        steelText.text = steelQ + " - Steel";
        fuelText.text = fuelQ + " - Fuel";
    }

    public void ResourceDestroy(string source, int resourceToDestroy)
    {
        for (int i = 0; i < resourceToDestroy; i++)
        {
            if (source.Equals("stone"))
            {
                stoneQ--;
            }
            else if (source.Equals("steel"))
            {
                steelQ--;
            }
            else if (source.Equals("fuel"))
            {
                fuelQ--;
            }
            else
            {
                break;
            }
        }

        stoneText.text = stoneQ + " - Stone";
        steelText.text = steelQ + " - Steel";
        fuelText.text = fuelQ + " - Fuel";
    }

}
