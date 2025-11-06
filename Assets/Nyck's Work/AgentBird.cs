using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
public class AgentBird : Agent
{
    public Rigidbody2D rb;
    public float flapForce;
    public float groundY;
    float flapCooldown = 0.2f;
    float lastFlapTime;

    private void Update()
    {
        float tilt = Mathf.Clamp(rb.linearVelocity.y * 5f, -45f, 45f);
        transform.rotation = Quaternion.Euler(0, 0, tilt);
    }
    public override void OnEpisodeBegin()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = new Vector2(0,-1);

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position.y);
        sensor.AddObservation(rb.linearVelocity.y);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        int flap = actions.DiscreteActions[0];

        if(flap == 1 && Time.time - lastFlapTime > flapCooldown)
        {
            rb.linearVelocityY = 0;
            rb.AddForce(Vector2.up  * flapForce, ForceMode2D.Impulse);
            lastFlapTime = Time.time;
        }

        if(transform.position.y > groundY)
        {
            AddReward(0.01f);

        }

        if(transform.position.y <= groundY)
        {
            AddReward(-1f);
            EndEpisode();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipes"))
        {
            AddReward(-1f);
            EndEpisode();
        }

        if (collision.CompareTag("Scorer"))
        {
            AddReward(+1f);  
        }
    }

}
