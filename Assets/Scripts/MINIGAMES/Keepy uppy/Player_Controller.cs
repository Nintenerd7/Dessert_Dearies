using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    float BounceForce = 15; //controls the force of the ball
    public Rigidbody2D _rigidbody; //rigidbody physics that adds force to the ball
    bool canBounce = false; //controls how many times you click the trigger collision 

    void Update()//updates sequences in every frame. 
    {
        if (Input.GetMouseButtonDown(0) && canBounce) //if you press on the circle 
        {
            BounceButton(); // call bounce button logic
        } //end if
    }
    
    void OnTriggerEnter2D(Collider2D col) //Ontrigger enter detects the bounce area and checks if the player can bounce the ball upwards 
    {
    if (col.tag == "BounceArea")//if collision tag is equal to bounce area 
        {
            canBounce = true;//canBounce is set to true.
        }//end if 
    else if (col.tag == "Death Zone") //else if collision tag is equal to death zone 
        {
            Destroy(gameObject); //ball is destroyed
            //game over 
        }//end else if 
    }

    void OnTriggerExit2D(Collider2D other)//ontrigger exit is for when the ball is outside of the bounce area 
    {
        canBounce = false; //can bounce is set to false, the player cannot bounce outside of bounce area
    }

    public void BounceButton() //handling the bounce force and the rigidbody force logic 
    {
            _rigidbody.AddForce(new Vector3(0, BounceForce), ForceMode2D.Impulse); //rigidbody adds force to bounce force value. 

    }//end method 
}
