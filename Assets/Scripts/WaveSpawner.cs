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

    private int wave_index = 0;

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
            wave_index++;
            ready = false;
            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave(){
        
        if (spawning == false)
        {
            spawning = true;
            for (int i = 0; i < wave_index; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }
            spawning = false;
        }else
        {
            Debug.Log("Already Spawning!");
        }

    }

    void SpawnEnemy(){
        Instantiate(basicEnemy, spawnPoint.position, spawnPoint.rotation);
    }

}
