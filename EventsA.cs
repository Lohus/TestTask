using UnityEngine.Events;

public static class EventsA
{
    public static UnityEvent<string> ArmyDeath = new UnityEvent<string>();
    public static UnityEvent StartButtle = new UnityEvent();
    public static UnityEvent ChangeProperty = new UnityEvent();
    public static UnityEvent RewardGame = new UnityEvent();
    
}