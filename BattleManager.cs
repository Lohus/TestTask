using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject prefabUnit;
    [SerializeField] Army[] armies;
    void Start()
    {
        
        for (int i = 0; i < armies.Count(); i++)
        {
            //armies[i].GenerateArmy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
