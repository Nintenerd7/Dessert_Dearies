using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pet_Data : MonoBehaviour
{
    [SerializeField] GameObject pet;//recycle for re-usable gameObject
    public Sprite[] happyPets;//recycle this for new game object
    public int petType; //used to index sprite types (recycle)
    public string Scene_Name; //contains name of the scene
    // Start is called before the first frame update
public void SetPet()
    {
        switch (petType)
        {
            case 0:
                pet.GetComponent<SpriteRenderer>().sprite = happyPets[0];
                break;
            case 1:
                pet.GetComponent<SpriteRenderer>().sprite = happyPets[1];
                break;
            case 2:
                pet.GetComponent<SpriteRenderer>().sprite = happyPets[2];
                break;
            case 3:
                pet.GetComponent<SpriteRenderer>().sprite = happyPets[3];
                break;
            case 4:
                pet.GetComponent<SpriteRenderer>().sprite = happyPets[4];
                break;
            case 5:
                pet.GetComponent<SpriteRenderer>().sprite = happyPets[5];
                break;
        }
    }

    public void LoadPet()
    {
        if (PlayerPrefs.HasKey("PetType"))
        {
            int savedType = PlayerPrefs.GetInt("PetType");
            petType = savedType;
            if (SceneManager.GetActiveScene().name == Scene_Name)
            {
                SetPet();
            }
        }
        else
        {
            petType = 0;
            if (SceneManager.GetActiveScene().name == Scene_Name)
            {
                SetPet();
            }
        }
    }
}
