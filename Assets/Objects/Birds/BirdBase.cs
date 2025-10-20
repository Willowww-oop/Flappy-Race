using UnityEngine;
using UnityEngine.InputSystem;

public class BirdBase : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BirdStats stats;
    float jumpStrength;
    PlayerInput playerInput;
    Rigidbody2D rigidBody;
    
    void Start()
    {
        jumpStrength = stats.jumpStrength;
        playerInput = GetComponent<PlayerInput>();
        rigidBody =  GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnJump()
    {
        //zero out the velocity so that its more cartoony 
        rigidBody.linearVelocityY = 0;
        
        rigidBody.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
    }
    
}
