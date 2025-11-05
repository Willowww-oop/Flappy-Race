using System.IO;
using System.Timers;
using UnityEditor;
using UnityEngine;
using Timer = System.Timers.Timer;


public class Pipespawner : MonoBehaviour
{
    public PipeSpawnerSO pipeSpawnerSO;
    //could make these just be wrappers for the SO but ughhhhhhhhhhhhhhh
    float SpawnSpeed = 1;
    GameObject Pipes;
    System.Random random = new System.Random();
    float deviation;

    float spawntime;
    
    
    void Start()
    {
        SpawnSpeed = pipeSpawnerSO.spawnSpeed;
        
        //
        Pipes = pipeSpawnerSO.prefab;
        deviation = pipeSpawnerSO.deviation;
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
        float offset = ((Random.value * 2) -1) * SpawnSpeed;
        var pos = transform.position;
        pos.y += offset;
        Instantiate(pipeSpawnerSO.prefab, pos, transform.rotation);
        Debug.Log("Spawned Pipes");
    }
}
