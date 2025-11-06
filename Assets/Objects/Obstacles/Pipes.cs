using UnityEngine;

public class Pipes : MonoBehaviour
{
    public PipesSO pipesSO;
    float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = pipesSO.speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
