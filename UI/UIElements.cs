using UnityEngine;

public class UIELements : MonoBehaviour
{
    Property[] meshProperties;
    Property[] colorProperties;
    Property[] sizeProperties;
    public void Start()
    {
        meshProperties = Resources.LoadAll<Property>("Property/Mesh");
        colorProperties = Resources.LoadAll<Property>("Property/Color");
        sizeProperties = Resources.LoadAll<Property>("Property/Size");
    }
    public void StartBattle()
    {
        EventsA.StartButtle?.Invoke();
    }
    public void RandomButton(Army army)
    {
        if (army.properties.Count != 0)
        {
            army.properties.Clear();
        }
        army.properties.Add(meshProperties[Random.Range(0, meshProperties.Length)]);
        army.properties.Add(colorProperties[Random.Range(0, colorProperties.Length)]);
        army.properties.Add(sizeProperties[Random.Range(0, sizeProperties.Length)]);
        EventsA.ChangeProperty?.Invoke();
    }
}