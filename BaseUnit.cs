using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour, IDamageable
{
    [SerializeField] public Army army { get; private set;}
    const float distance = 20;
    public int HP = 100;
    public int ATK = 10;
    public int SPEED = 10;
    public float ATKSPD = 1;
    public BaseUnit target = null;
    bool isAttacking = false;
    private Coroutine attackCoroutine;
    public void ApplyProperty()
    {
        if (army.properties.Count != 0)
        {
            foreach (Property property in army.properties)
            {
                property.ApplyProperty(this);
            }
        }
    }
    void Update()
    {
        Move();
    }
    public void TakeDamage(int damage)
    {
        Debug.Log(gameObject.name + " take " + damage + " damage");
        HP -= damage;
        if (HP <= 0)
        {
            Debug.Log(gameObject.name + " destoyed");
            army.KillUnit(gameObject);
            Destroy(gameObject);
        }
    }
    public void Move()
    {
        if (target != null)
        {
            transform.LookAt(target.transform);
            if((target.transform.position - transform.position).magnitude > 1.5)
            {
                if (isAttacking)
                {
                    StopAttack();
                }
                transform.Translate(new Vector3(0,0, SPEED) * Time.deltaTime);
            }
            else
            {
                if (!isAttacking)
                {
                    attackCoroutine = StartCoroutine(AttackTarget());
                }
            }
        }
        else
        {
            StopAttack();
            Search();
        }
    }
    public void Attack(IDamageable target, int damage)
    {
        Debug.Log(gameObject.name + " attack " + target);
        target.TakeDamage(damage);
    }
    public void Search()
    {
        if (target == null)
        {
            if (Physics.CheckSphere(transform.position, distance))
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, distance);
                float closestDistance = float.MaxValue; 
                foreach (Collider col in colliders)
                {
                    if (col.TryGetComponent<BaseUnit>(out BaseUnit unit))
                    {
                        if (unit != this && army.id != unit.army.id)
                        {
                            float distanceToUnit = Vector3.Distance(col.transform.position, transform.position);
                            if (distanceToUnit < closestDistance)
                                {
                                    closestDistance = distanceToUnit;
                                    target = unit;
                                }
                        }
                    }
                }
            }
        }
    }
    public void BattleRage()
    {
        ATK *= 2;
    }

    IEnumerator AttackTarget()
    {
        isAttacking = true;
        while (target != null && (target.transform.position - transform.position).magnitude <= 2)
        {
            Attack(target, ATK);
            yield return new WaitForSeconds(ATKSPD);
        }
    }
    private void StopAttack()
    {
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }
        isAttacking = false;
    }
    public void SetArmy(Army army)
    {
        this.army = army;
    }
    void OnDestroy()
    {
        StopAttack();
    }
}
