using System.IO;
using System.Timers;
using UnityEditor;
using UnityEngine;
using Timer = System.Timers.Timer;

public class Pipespawner : MonoBehaviour
{
    public PipeSpawnerSO pipeSpawnerSO;
    float SpawnSpeed = 1;
    GameObject Pipes;

    float spawntime;
    
    
    void Start()
    {
        SpawnSpeed = pipeSpawnerSO.spawnSpeed;
        
        //
        Pipes = pipeSpawnerSO.prefab;
    }

    // Update is called once per frame
    void Update()
    {
        spawntime += Time.deltaTime;
        if (!(spawntime >= SpawnSpeed))
            return;
        spawntime = 0;
        SpawnElapsed();
    }

    void SpawnElapsed()
    {
        Instantiate(pipeSpawnerSO.prefab, transform.position, transform.rotation);
        Debug.Log("Spawned Pipes");
    }
}
