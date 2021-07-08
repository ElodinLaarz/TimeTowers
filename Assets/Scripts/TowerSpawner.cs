using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    private GameObject tower_to_spawn = null;
    
    private void Update() {
        if(Input.GetMouseButtonDown(1))
        {
            SpawnTower();
        }
    }


    public void SetTower(GameObject tower)
    {
        tower_to_spawn = tower;
    }

    public void SpawnTower()
    {
        if (tower_to_spawn == null)
        {
            Debug.Log("Please select a Tower first!");
            return;
        }
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 world_position = Camera.main.ScreenToWorldPoint(mousePos);
        world_position.z = 0;
        
        Instantiate(tower_to_spawn, world_position, Quaternion.identity);
        SetTower(null);
    }

}
