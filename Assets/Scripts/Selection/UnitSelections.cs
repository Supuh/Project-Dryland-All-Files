using System.Collections.Generic;
using UnityEngine;

public class UnitSelections : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitsSelected = new List<GameObject>();

    private static UnitSelections _instance;
    public static UnitSelections Instance { get { return _instance; } }

    private void Awake()
    {
        // singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void addSelection(GameObject unitToAdd)
    {
        unitsSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        unitToAdd.GetComponent<UnitMovement>().enabled = true;
    }

    private void removeSelection(GameObject unitToRemove)
    {
        unitsSelected.Remove(unitToRemove);
        unitToRemove.transform.GetChild(0).gameObject.SetActive(false);
        unitToRemove.GetComponent<UnitMovement>().enabled = false;
    }

    public void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll();
        addSelection(unitToAdd);
    }

    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if (unitsSelected.Contains(unitToAdd))
        {
            removeSelection(unitToAdd);
        }
        else
        {
            addSelection(unitToAdd);
        }
    }

    public void DragSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd))
        {
            addSelection(unitToAdd);
        }
    }

    public void DeselectAll()
    {
        foreach (var unit in unitsSelected)
        {
            unit.GetComponent<UnitMovement>().enabled = false;
            unit.transform.GetChild(0).gameObject.SetActive(false);
        }

        unitsSelected.Clear();
    }

    public void Deselect(GameObject unitToDeselect)
    {

    }

}
