using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth=100f;
    [SerializeField] TextMeshProUGUI healthText;
    private void Update() {
        healthText.text=playerHealth.ToString();
    }
    public void playerTakeDamage(float enemyDamage)
    {

        playerHealth-=enemyDamage;
        if(playerHealth<=0)
        {
            
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
