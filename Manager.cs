using UnityEngine;

public class Manager : MonoBehaviour
{
    [Header("Base Stats")]
    [SerializeField] private int Health = 100;
    [SerializeField] private int Attack = 10;
    [SerializeField] private int Speed = 10;
    [SerializeField] private float AttackSpeed = 1;
    // Start is called before the first frame update
    void Awake()
    {
        BaseStats.SetStats(Health, Attack, Speed, AttackSpeed);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
