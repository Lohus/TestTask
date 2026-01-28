using System.Collections.Generic;
public class Army
{
    private static int _count = 0;
    public int id { get; private set;} = 0;
    public string name;
    public int countUnits {get; private set;}
    public int maxUnitInArmy {get; private set;} = 20;
    List<BaseUnit> units;
    public Army()
    {
        _count ++;
       id = _count;
       name = $"Army {id}";
    }
    public void AddUnit(BaseUnit unit)
    {
        if (units.Count < maxUnitInArmy) units.Add(unit);
    }
    public void RemoveUnit(BaseUnit unit)
    {
        units.Remove(unit);
    }
}