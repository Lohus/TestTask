using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Threading.Tasks;

public class SimpleMeshDropdown : MonoBehaviour
{
    public string folder;
    public Army army;
    private TMP_Dropdown dropdown;
    private TextMeshProUGUI label;
    private Property[] properties;
    
    public async void Start()
    {
        label = transform.Find("Label").GetComponent<TextMeshProUGUI>();
        EventsA.ChangeProperty.AddListener(Refresh);
        dropdown = gameObject.GetComponent<TMP_Dropdown>();
        properties = Resources.LoadAll<Property>($"Property/{folder}");        
        dropdown.onValueChanged.AddListener((index) => SelectProperty(army, properties[index]));
        await Task.Delay(500);
        Refresh();
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
        if (army.properties.Count == 0 && army.properties != null)
        {
            label.text = folder;
        }
        else
        {
            foreach(Property prop in army.properties)
            {
                if (prop.GetType() == properties[0].GetType())
                {
                    label.text = prop.name;
                }
            }
        }
    }
    public void OnDestroy()
    {
        EventsA.ChangeProperty.RemoveListener(Refresh);
        dropdown.onValueChanged.RemoveListener((index) => SelectProperty(army, properties[index]));
    }
}