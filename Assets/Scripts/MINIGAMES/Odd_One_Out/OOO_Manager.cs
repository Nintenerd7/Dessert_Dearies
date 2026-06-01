using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOO_Manager : MonoBehaviour
{
    bool Has_Answer;
    //create a shuffle function for when the game begins and when the player gets a correct answer
    //Create a way to assign images to buttons.
    // add a timer to create preassure on the player. 
    
    public void WrongAnswerBTN()
    {
      Has_Answer = false;
    }

    public void RightAnswerBTN()
    {
       Has_Answer = true;
    }
}
