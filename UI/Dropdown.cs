using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleMeshDropdown : MonoBehaviour
{
    public string folder;
    public Army army;
    private TMP_Dropdown dropdown;
    private Property[] properties;
    
    void Start()
    {
        EventsA.ChangeProperty.AddListener(Refresh);
        dropdown = gameObject.GetComponent<TMP_Dropdown>();
        properties = Resources.LoadAll<Property>($"Property/{folder}");
        
        Refresh();
        
        dropdown.onValueChanged.AddListener((index) => SelectProperty(army, properties[index]));

    }
    public void SelectProperty(Army army, Property property)
    {
        if (army.properties.Count == 0 )
        {
            army.properties.Add(property);
        }
        else
        {
            for(int i = 0; i < army.properties.Count; i++)
            {
                if(army.properties[i].GetType() == property.GetType())
                {
                    army.properties[i] = property;
                } 
            }
        }
    }
    void Refresh()
    {
        dropdown.ClearOptions();
        foreach (var mesh in properties)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData(mesh.name));
        }
    }
    public void Oestroy()
    {
        EventsA.ChangeProperty.RemoveListener(Refresh);
        dropdown.onValueChanged.RemoveListener((index) => SelectProperty(army, properties[index]));
    }
}