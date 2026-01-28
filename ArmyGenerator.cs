using UnityEngine;

public class ArmyGenerator: MonoBehaviour
{
    [SerializeField] float sizeX = 1;
    [SerializeField] float sizeZ = 1;
    [SerializeField] int countX = 5;
    [SerializeField] int countZ = 4;
    [SerializeField] float height = 0.5f;
    public GameObject prefUnit;
    private GameObject[,] gridUnits;
    private Vector3 startPosition;
    public void Start()
    {
        startPosition = transform.position - new Vector3(2 * sizeX, 0, 0);
    }
    public void GenerateArmy(Army army)
    {
        gridUnits = new GameObject[countX, countZ];
        for (int x = 0; x < countX; x++)
        {
            for (int z = 0; z < countZ; z++ )
            {
                Vector3 cellPosition = startPosition + new Vector3(x * sizeX, height, z * sizeZ);
                gridUnits[x, z] = Instantiate(prefUnit, cellPosition, transform.rotation);
                gridUnits[x, z].GetComponent<BaseUnit>().SetArmy(army);
            }
        }
    }
}