using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Header("Enemy Types")]
    public Transform basicEnemy;

    [Header("Starting Location")]
    public Transform spawnPoint;


    bool ready = false;
    bool spawning = false;

    private int wave_number = 0;

    public void ReadyUp(){
        ready = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ready == true){
            ready = false;
            spawning = true;
            wave_number++;
            SpawnWave();
        }
    }

    void SpawnWave(){
        
        for (int i = 0; i < wave_number; i++)
        {
            SpawnEnemy();
        }
        spawning = false;

    }

    void SpawnEnemy(){
        Instantiate(basicEnemy, spawnPoint.position, spawnPoint.rotation);
    }

}
