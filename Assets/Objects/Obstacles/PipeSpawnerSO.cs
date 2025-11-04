using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "PipeSpawnerSO", menuName = "Scriptable Objects/PipeSpawnerSO")]
public class PipeSpawnerSO : ScriptableObject
{
    public float spawnSpeed;
    public GameObject prefab;
    public float deviation;

}
