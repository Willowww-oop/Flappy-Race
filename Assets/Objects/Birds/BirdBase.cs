using System;
using System.Collections.Generic;
using HelperScripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdBase : MonoBehaviour
{
    //this name doesnt really make sense anymore but whatever
    public BirdStats stats;
    float jumpStrength;
    PlayerInput playerInput;
    Rigidbody2D rigidBody;
    GameObject global;
    private int _score = 0;
    GameObject spriteObj;
    SpriteRenderer spriteRenderer;
    const float rotationAmt = 5;
    
    
    //sprite sets, would change based on the user choice if they want
    List<Sprite[]> spriteSets;

    Sprite[] currentSpriteSet;
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
        spriteObj = transform.GetChild(0).gameObject;
        spriteRenderer = spriteObj.GetComponent<SpriteRenderer>();
        global = GameObject.Find("GlobalObject");
        
        //spritesets
        
        spriteSets = new List<Sprite[]>();
        spriteSets.Add(stats.spriteSetYellow);
        currentSpriteSet = spriteSets[0];
    }

    // Update is called once per frame
    void Update()
    {
        spriteObj.transform.rotation = Quaternion.Euler(0, 0, rigidBody.linearVelocity.y * rotationAmt);
        switch (rigidBody.linearVelocity.y)
        {
            case > 2:
                spriteRenderer.sprite = currentSpriteSet[2];
                break;
            case < -2:
                spriteRenderer.sprite = currentSpriteSet[1];
                break;
            default:
                spriteRenderer.sprite = currentSpriteSet[0];
                break;
        }
    }

    public void OnJump()
    {
        //zero out the velocity so that its more cartoony (feel free to fuck with this)
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
