using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Controller : MonoBehaviour
{
    float BounceForce = 10; //controls the force of the ball
    public Rigidbody2D _rigidbody; //rigidbody physics that adds force to the ball
    bool canBounce = false; //controls how many times you click the trigger collision 
    public TMP_Text ScoreText; //Reference to text mesh pro element in the UI canvas
    public GameObject[] Toggle = new GameObject[4];
    int ScoreCount; //Score count stores the value of the score parameter 

    void Update()//updates sequences in every frame. 
    {
        if (Input.GetMouseButtonDown(0) && canBounce) //if you press on the circle 
        {
            BounceButton(); // call bounce button logic
            AddScore(10);//Call add score, Parameter adds 10 score points for each tap or mouse click
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
            GameOver(); //call gameover
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

    public void AddScore(int score) // Add score method is used to add a value to the scoreboard hud. 
    {
      ScoreCount += score; //score parameter is assigned to the score count 
      ScoreText.text = ScoreCount.ToString(); // score count is converted to string within the text mesh pro text
    }//end method 

    public void GameOver()
    {
      Toggle[0].SetActive(true);
      Toggle[1].SetActive(false);
      Toggle[2].SetActive(false);
      Toggle[3].SetActive(false);
    }
}
