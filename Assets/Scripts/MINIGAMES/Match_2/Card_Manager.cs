using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card_Manager : MonoBehaviour
{
    [SerializeField] Image Image;//used to change the sprite 
    public Sprite IconSprite; //used to make the icon sprite 
    public Sprite HiddenIcon; //used to show the hidden card icon 
    public bool flipped = false;//Boolean for flipping cards 
    public Match2_Manager Controller;//Object reference for Icon Index 

    public void onclick()
    {
        Controller.selectCard(this);//select card is set to card manager 
    }

    //flip button function 
    public void Show_Card()//used to flip the card 
    {
        flipped = true;
        Image.sprite = IconSprite;
    }

    public void HideCard()
    {
        flipped = false;
        Image.sprite = HiddenIcon;
    }
   public void showImg(Sprite img)
    {
        IconSprite = img;
    }
 
}