using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    private int max_health = 60;
    private int current_health = 60;

    public RectTransform healthbar;
    
    public void TakeDamage(int damage)
    {
        current_health -= damage;
        if (current_health <= 0)
        {
            Destroy(gameObject);
            return;
        }

        healthbar.sizeDelta = new Vector2(current_health, healthbar.sizeDelta.y);
    }
}
