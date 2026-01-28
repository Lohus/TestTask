static public class BaseStats
{
    static int HP = 100;
    static int ATK = 10;
    static int SPEED = 10;
    static float ATKSPD = 1;
    static public void SetStats(int _HP, int _ATK, int _SPEED, float _ATKSPD)
    {
        HP = _HP;
        ATK = _ATK;
        SPEED = _SPEED;
        ATKSPD = _ATKSPD;
    }
    static public void GetStats(BaseUnit baseUnit)
    {
        baseUnit.HP = HP;
        baseUnit.ATK = ATK;
        baseUnit.SPEED = SPEED;
        baseUnit.ATKSPD = ATKSPD;
    }
}
