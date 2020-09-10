using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] PlayerHealth target;
    [SerializeField] float enemyDamage=20f;
    void Start()
    {
        target=FindObjectOfType<PlayerHealth>();
    }
    public void AttackHitEvent()
    {
        if(target==null){
            return;
        }
        target.playerTakeDamage(enemyDamage);
        target.GetComponent<DisplayDamage>().ShowDamageSplatter();

    }

}
