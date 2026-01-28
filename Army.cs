using System.Collections.Generic;
using UnityEngine;
public class Army: MonoBehaviour
{
    [SerializeField] GameObject prefabUnit;
    private static int _count = 0;
    public int id { get; private set;} = 0;
    public string name;
    public int countUnits {get; private set;}
    public int maxUnitInArmy {get; private set;} = 20;
    List<GameObject> units = new List<GameObject>();
    public void GenerateArmy()
    {
        ArmyGenerator.instance.GenerateArmy(this, prefabUnit, transform);
    }
    public Army()
    {
        _count ++;
       id = _count;
       name = $"Army {id}";
    }
    public void AddUnit(GameObject unit)
    {
        if (units.Count < maxUnitInArmy) units.Add(unit);
    }
    public void RemoveUnit(GameObject unit)
    {
        units.Remove(unit);
    }
}