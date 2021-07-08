using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]

    public float range = 4.0f;
    public float fire_rate = 1f;
    private float fire_countdown = 0f;

    [Header("Unity Setup Fields")]

    public string enemy_tag = "Enemy";
    public GameObject projectile_prefab;
    public Transform fire_point;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemy_tag);
        float shortest_distance = Mathf.Infinity;
        GameObject nearest_enemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance_to_enemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance_to_enemy < shortest_distance)
            {
                shortest_distance = distance_to_enemy;
                nearest_enemy = enemy;
            }
        }

        if (shortest_distance <= range && nearest_enemy != null)
        {
            target = nearest_enemy.transform;
        }else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        
        if (fire_countdown <= 0f)
        {
            Shoot();
            fire_countdown = 1f/fire_rate;
        }

        fire_countdown -= Time.deltaTime;
    }

    void Shoot()
    {
        Debug.Log("Shoot!");
        GameObject projectile_GO = (GameObject) Instantiate (projectile_prefab, fire_point.position, fire_point.rotation);
        Projectile projectile = projectile_GO.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.Seek(target);
        }  
    }


    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
