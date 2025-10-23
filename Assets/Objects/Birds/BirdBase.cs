using System;
using HelperScripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdBase : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BirdStats stats;
    float jumpStrength;
    PlayerInput playerInput;
    Rigidbody2D rigidBody;
    GameObject global;
    private int _score = 0;
    public event EventHandler OnUpdateScore;
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            //this'll be useful for ui stuff
            OnUpdateScore?.Invoke(this, EventArgs.Empty);
            Debug.Log($"Score: {_score}");
        }
        
    }
    
    void Start()
    {
        jumpStrength = stats.jumpStrength;
        playerInput = GetComponent<PlayerInput>();
        rigidBody =  GetComponent<Rigidbody2D>();
        global = GameObject.Find("GlobalObject");
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Scorer"))
        {
            //note: I made it so that the method takes in an int to add to the score, instead of just incrementng it, so that the scoreres can have different score values if we want
            //update: im dumb lol
            Score += 1;
        }
    }
    
}
