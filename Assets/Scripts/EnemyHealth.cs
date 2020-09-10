using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemysHealth=100f;
    bool isDead=false;
    public bool IsDead()
    {
        return isDead;
    }
    public void TakeDamage(float damage){
        
        enemysHealth-=damage;
        print(enemysHealth);
        if (enemysHealth<=0)
        {
            Die();
        }
        if (enemysHealth<100)
        {
            GetComponent<EnemyAi>().OnDamageTaken();
        }

    }

    private void Die()
    {
        if (isDead)
        {
            return;
        }
        isDead=true;
        GetComponent<Animator>().SetTrigger("Death");
    }
}
