using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match2_Manager : MonoBehaviour
{
    //Internal variables
    public Card_Manager cardPrefab; //placeholder for instansiating the object reference 
    public Transform grid; //detect the grid layout transform 
    public Sprite[] icons; //gets icon list 
    private List<Sprite> Pairs; //creates list of pairs 
    int count; //keeps score of when the game will end
    public GameObject text; //sets the game over text to true when the game ends 
    bool gotPoint = false; //checks if the player can score in the update function. 
    Card_Manager A; //Stores the first card 
    Card_Manager B; //stores the second card 


    public void selectCard(Card_Manager card)
    {
        if (!card.flipped)
        {
            card.Show_Card();
            if (A == null)
            {
                A = card;
                return;
            }
            if (B == null)
            {
                B = card;
                StartCoroutine(CheckMatch(A, B));
                A = null;
                B = null;
            }
        }
    }

    IEnumerator CheckMatch(Card_Manager a, Card_Manager b)
    {
        yield return new WaitForSeconds(0.3f);

        if(a.IconSprite == b.IconSprite)
        {
            Destroy(a.gameObject);
            Destroy(b.gameObject);
            gotPoint = true;
        }
        else
        {
            a.HideCard();//hides card if incorrect
            b.HideCard();//hides card if incorrect
        }
    }

    // Update is called once per frame
    void Start()
    {
        GenerateSprites();//call generate sprites to start 
        CreateCards();//Call create cards to start 
    }

    void Update()
    {
      if (gotPoint)
      {
        count += 1;
        gotPoint = false;
      }
      if (count == 6)
      {
        text.SetActive(true);
      }
    }
    void GenerateSprites() //generates icon sprites 
    {
        Pairs = new List<Sprite>();//creates new list
        for (int i = 0; i < icons.Length; i++)//for how many icons are in the index 
        {
            Pairs.Add(icons[i]);//adds a pair 
            Pairs.Add(icons[i]);//adds a pair 
        }
        ShuffleSprites(Pairs);//call the shuffle sprites method 
    }//end of function

    void CreateCards() //instansiates cards 
    {
        for (int i = 0; i < Pairs.Count; i++) //for each element in the pair list count 
        {
            Card_Manager card = Instantiate(cardPrefab, grid);//instansiate card prefab in the grid layout 
            card.showImg(Pairs[i]);//icon sprite is assigned to pairs list 
            card.Controller = this; //assigns icon index as cards selected object reference
        }//end of loop 
    }
    void ShuffleSprites( List <Sprite> Shuffle_List) //Shuffle sprites: used to randomize the sprite position 
    {
        for (int i = Shuffle_List.Count - 1; i > 0; i--)//for each element in the list 
        {
            int rand = Random.Range(0, i + 1); //randomizes sprites 
            Sprite temp = Shuffle_List[i]; //uses sprite parameter to intiialize sprites 
            Shuffle_List [i] = Shuffle_List[rand];//Shuffle list index is equal to the rand var 
            Shuffle_List [rand] = temp;//Shuffle List is equal to temp variable 
        }//end loop 
    }//end of function

}
