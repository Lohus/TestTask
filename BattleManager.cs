using Unity.VisualScripting;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject prefabUnit;
    public ArmyGenerator generatorArmy1, generatorArmy2;
    private Army[] armies = new Army[2];
    void Start()
    {
        armies[0] = new Army();
        armies[1] = new Army();
        generatorArmy1.GenerateArmy(armies[0]);
        generatorArmy2.GenerateArmy(armies[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
