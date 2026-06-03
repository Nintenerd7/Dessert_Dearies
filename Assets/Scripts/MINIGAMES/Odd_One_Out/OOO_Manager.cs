using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public enum sets
{
  set1,
  set2,
  set3,
  set4,
  set5,
  set6,
}

public class OOO_Manager : MonoBehaviour
{
    float timeLeft = 10f; //reference for the amount of time the player has to play the game 
    public Transform grid; //reference for the buttons parent "Board"
    public OOO_Index[] SpriteData; //contains OOO index variables 
    public Image BTNPrefab; //holds prefab for button
    private List<Sprite> set; //creates list of sets
    sets DeckSet;

    void Start() //starts at the beginning of the sequence 
    {
      DeckSet = sets.set4;
    }
    void Update()//updates each second of the frame
    {
       Timer();//begin timer
    switch(DeckSet)
    {
      case sets.set1: GenerateSet(0); GenerateCards();break;
      case sets.set2: GenerateSet(1); GenerateCards();break;
      case sets.set3: GenerateSet(2); GenerateCards();break;
      case sets.set4: GenerateSet(3); GenerateCards();break;
      case sets.set5: GenerateSet(4); GenerateCards();break;
      case sets.set6: GenerateSet(5); GenerateCards();break;
    }
    }

public void GenerateCards() //this is the main method that spawns the buttons and randomizes their positions at the start of the game
{
     for(int i = 0; i <= 3; i++) //for each button that is the same copy of the incorrect card 
     {
      //add boolean here in the morning 
      Instantiate(BTNPrefab, grid); //Spawn button within grid 
      BTNPrefab.sprite = set[i];
     }
}

public void test()
{
 int rand = Random.Range (0,5);


 Debug.Log(rand);
}
public void GenerateSet(int index) //contains what sprite set will be assigned to the current card sequence. having three duplicates and one odd card. 
{
         set = new List<Sprite>();//creates new list
            set.Add(SpriteData[1].ImageVariant[index]); 
            set.Add(SpriteData[0].ImageVariant[index]); 
            set.Add(SpriteData[0].ImageVariant[index]); 
            set.Add(SpriteData[0].ImageVariant[index]); 
}

//create randomized sets 

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
