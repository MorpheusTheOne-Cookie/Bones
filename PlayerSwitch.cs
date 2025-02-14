using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{

    public Player Player1;
    public Player2 Player2;
    public bool player1Active = true;
    public Rigidbody2D rigidBody1;
    public Rigidbody2D rigidBody2;
    public SpriteRenderer Sprite1;
    public SpriteRenderer Sprite2;
    public BoxCollider2D Box1;
    public BoxCollider2D Box2;
    public BoxCollider2D CeilingBox1;
    public BoxCollider2D CeilingBox2;







    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            SwitchPlayer();
        }
    }

    public void SwitchPlayer (){

        if(player1Active){
            Player1.enabled = false;
            rigidBody1.simulated = false;
            Sprite1.enabled = false;
            Box1.enabled = false;
            CeilingBox1.enabled = false;
            
            Player2.enabled = true;
            rigidBody2.simulated = true;
            Sprite2.enabled = true;
            Box2.enabled = true;
            CeilingBox2.enabled = true;


            player1Active = false;

        }

        else{
            Player1.enabled = true;
            rigidBody1.simulated = true;
            Sprite1.enabled = true;
            Box1.enabled = true;
            CeilingBox1.enabled = true;

            Player2.enabled = false;
            rigidBody2.simulated = false;
            Sprite2.enabled = false;
            Box2.enabled = false;
            CeilingBox2.enabled = false;

            player1Active = true;
        }
    }
}
