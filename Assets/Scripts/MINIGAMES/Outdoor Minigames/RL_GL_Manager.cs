using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_GL_Manager : MonoBehaviour
{
    bool CanWalk; //to heck if the player is moving during the redlight sequence
    bool paused; //Checks if the game can be paused 
    bool TargetReached; //checks if the player has one  
    public int petType; //used to index sprite types
    public state GameMode; //used to set game modes 
    float speed = 0.0005f; //used to store z speed value 

    void Start()
    {
        paused = false; //paused is set to false at the start of this frame 
    }

    // Update is called once per frame
   void Update()
    {
        MoveForward();
        CheckTarget();

        switch(GameMode) //controls the state machines 
        {
          case state.redlight:
          RedLight(); //calls greenlight in the green light state
          break; //break line

         case state.greenlight:
          GreenLight(); //calls greenlight in the green light state
          break;
        }//end switch

        if (TargetReached)
        {
          Debug.Log("WIN");
          StopAllCoroutines();
          paused = true;
        }
    }
void FixedUpdate() //for pausing the game when the player wins or loses 
{
        if (paused)
        {
          Time.timeScale = 0f;
        }
}
    void MoveForward()
    {
        CanWalk = false;
        TargetReached = false;
        if (Input.GetMouseButton(0) && !CanWalk && !TargetReached && !paused) //if the player taps on the screen or presses the mouse, and can walk is set to false and target reached is set to false 
        {
            CanWalk = true; //can walk is set to true 
            transform.position += new Vector3(0f, 0f, speed); //transform position moves along with the Z axis 
        }
    }

    void CheckTarget()
    {
        if (transform.position.z >= -5.016425f) // if the player has reached to the top of the hill 
        {
            TargetReached = true; //target reached is set to true 
            transform.position = new Vector3(0f, 0f, -5.016425f); // transform position is set to the top of the hill position on the Z axis. 
        }
    }

    void RedLight()
    {
       Debug.Log("red light");
       StopCoroutine(SwitchToRedLight());
       switch(CanWalk)
       {
        case true:
        if (!paused)StartCoroutine(TimeBeforeLoosing()); 
        break;
        case false:
        StartCoroutine(SwitchToGreenLight());
        break;
       }
    }

    void GreenLight()
    {
        Debug.Log("green light");
        StopCoroutine(SwitchToGreenLight());
        StartCoroutine(SwitchToRedLight());
    }

public IEnumerator TimeBeforeLoosing() 
{ 
   yield return new WaitForSeconds(0.5f);
   paused = true;
   yield break;
}

public IEnumerator SwitchToGreenLight()
{
  yield return new WaitForSeconds(5f);
  GameMode = state.greenlight;
  yield break;
}

public IEnumerator SwitchToRedLight()
{
  yield return new WaitForSeconds(5f);
  GameMode = state.redlight;
  yield break;
}

    public enum state
    {
        redlight,
        greenlight,
    }

}

