using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutsidePathfinding : MonoBehaviour
{
    [SerializeField]GameObject PetShadow;
    [SerializeField] GameObject pet;
    public GameObject FootballPrefab;
    GameObject football;
    Vector2 TargetPos;
    [SerializeField] float Speed = 1.0f;
    private bool HasTargetPos = false;
    [SerializeField] Animator WalkCycle;
    bool setInvoke = false;
    public Sprite[] happyPets;
    public int petType;

    // Start is called before the first frame update
    void Start()
    {
        LoadPet();
        CheckForBall();
        SetTargetPos();
    }

    // Update is called once per frame
    void Update()
    {

        if (HasTargetPos)
        {
            Debug.Log("TargetPos = " + TargetPos);
            if(Vector2.Distance(new Vector2(PetShadow.transform.position.x, PetShadow.transform.position.y), TargetPos) <= 0.05f)
            {
                WalkCycle.SetBool("HasTargetPos", false);
                if(!setInvoke)
                {
                    Invoke("SetTargetPos", Random.Range(3f, 7f));
                    setInvoke = true;
                }
            }
            else
            {
                PetShadow.transform.position = Vector2.MoveTowards(PetShadow.transform.position, TargetPos, Speed);
            }
        }
        else
        {
            SetTargetPos();
        }
    }

    Vector2 SetTargetPos()
    {
        if(football==null)
        {
            TargetPos = new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(-5.0f, 0.0f));
            HasTargetPos = true;
            setInvoke = false;
            WalkCycle.SetBool("HasTargetPos", true);
        }
        else
        {
            TargetPos = new Vector2(football.transform.position.x, football.transform.position.y);
            HasTargetPos = true;
            setInvoke = false;
            WalkCycle.SetBool("HasTargetPos", true);
        }
        return TargetPos;
    }

    public void CheckForBall()
    {
        football = GameObject.Find("Ball");
    }

    public void SpawnBall()
    {
        if (football==null)
        {
            football = Instantiate(FootballPrefab, new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-5.0f, 0f), 0f), transform.rotation);
        }
    }

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
            if (SceneManager.GetActiveScene().name == "outside")
            {
                SetPet();
            }
        }
        else
        {
            petType = 0;
            if (SceneManager.GetActiveScene().name == "outside")
            {
                SetPet();
            }
        }
    }
}
