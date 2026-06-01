using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class OOO_Manager : MonoBehaviour
{
    float timeLeft = 10f; //reference for the amount of time the player has to play the game 
    public Transform grid; //reference for the buttons parent "Board"
    public OOO_Index[] SpriteData; //contains OOO index variables 
    public Image[] BTNPrefab = new Image[2]; //holds prefab for button


    void Start() //starts at the beginning of the sequence 
    {
      GenerateCards();//call generate cards at first sequence 
    }
    void Update()//updates each second of the frame
    {
       Timer();//begin timer 
    }

public void GenerateCards()
{
    //randomize button positions within the grid 
     for(int i = 0; i <= 2; i++) //for each button that is the same copy of the incorrect card 
     {
      CardData(SpriteData[0]);//generate ID 1 (Incorrect answers)
      Instantiate(BTNPrefab[0], grid); //Spawn button within grid 
     }
      CardData(SpriteData[1]);//generate ID 2 (Correct answers)
      Instantiate(BTNPrefab[1], grid);//Spawn Button Within Grid 
}


public void CardData(OOO_Index s) 
{
  for (int i = 0; i <= 1; i++)
  {
    BTNPrefab[i].sprite = s.ImageVariant[0];
  }
}

public void Timer()
{
  if (timeLeft > 0)
  {
     timeLeft -= Time.deltaTime;
  }
  if (timeLeft == 0)
  {
    //hide board 
  }
  }

  public void RightAnswer()
  {
    Debug.Log("Correct");
  }

    public void WrongAnswer()
  {
    Debug.Log("incorrect");
  }
}
