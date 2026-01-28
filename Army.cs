using System.Collections.Generic;
using UnityEngine;
public class Army: MonoBehaviour
{
    [SerializeField] GameObject prefabUnit;
    private static int _count = 0;
    public int id { get; private set;} = 0;
    public string nameArmy;
    public int countUnits {get; private set;}
    public int maxUnitInArmy {get; private set;} = 20;
    public List<Property> properties;
    List<GameObject> units = new List<GameObject>();

    public void OnEnable()
    {
        EventsA.StartButtle.AddListener(GenerateArmy);
    }
    public void OnDestroy()
    {
        EventsA.StartButtle.RemoveListener(GenerateArmy);
    }
    public void GenerateArmy()
    {
        ArmyGenerator.instance.GenerateArmy(this, prefabUnit, transform);
    }
    public Army()
    {
        _count ++;
       id = _count;
       nameArmy = $"Army {id}";
    }
    public void AddUnit(GameObject unit)
    {
        if (units.Count < maxUnitInArmy) units.Add(unit);
    }
    public void RemoveUnit(GameObject unit)
    {
        units.Remove(unit);
    }
    public void KillUnit(GameObject unit)
    {
        units.Remove(unit);
        if (units.Count == 0)
        {
            Debug.Log($"{nameArmy} is dead");
            EventsA.ArmyDeath?.Invoke(nameArmy);
        }
    }
}