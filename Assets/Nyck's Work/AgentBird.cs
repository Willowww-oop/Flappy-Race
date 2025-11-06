using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
public class AgentBird : Agent
{
    public Rigidbody2D rb;
    public float flapForce = 5f;
    public float groundY = 0f;

    public override void OnEpisodeBegin()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = new Vector2(0,2);

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position.y);
        sensor.AddObservation(rb.linearVelocity.y);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        int flap = actions.DiscreteActions[0];

        if(flap == 1)
        {
            rb.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);
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
        if (collision.CompareTag("Pipe"))
        {
            AddReward(-1f);
            EndEpisode();
        }
    }

}
