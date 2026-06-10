using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OutsidePathfinding : MonoBehaviour
{
    [SerializeField]GameObject PetShadow;
    Vector2 TargetPos;
    [SerializeField] float Speed = 1.0f;
    private bool HasTargetPos = false;
    [SerializeField] Animator WalkCycle;
    bool setInvoke = false;

    // Start is called before the first frame update
    void Start()
    {
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
        TargetPos = new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(-5.0f, 0.0f));
        HasTargetPos = true;
        setInvoke = false;
        WalkCycle.SetBool("HasTargetPos", true);
        return TargetPos;
    }

}
