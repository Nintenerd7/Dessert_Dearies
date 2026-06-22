using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Football : MonoBehaviour
{
    [SerializeField] private float Force = 1f;
    private Rigidbody2D rb;
    [SerializeField] float destroyTimer = 10f;
    bool hasKickedBall = false;
    private GameObject MainCamObj;
    private Camera MainCam;
    bool destroyWait = false;
    [SerializeField] Animator animator;
    [SerializeField] GameObject ballPoofPrefab;
    private GameObject ballPoof;
    [SerializeField] OutsidePathfinding outsidePathfinding;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        MainCamObj = GameObject.FindWithTag("MainCamera");
        MainCam = MainCamObj.GetComponent<Camera>();
    }

    private void Update()
    {
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
        CheckBoundaries();

        if(rb.velocity.y <= 0.01 && rb.velocity.x <= 0.01)
        {
            if(!destroyWait)
            {
                Invoke("DestroyBall", destroyTimer);
            }
            destroyWait = true;
        }
        else
        {
            if(destroyWait)
            {
                CancelInvoke("DestroyBall");
            }
            destroyWait=false;
        }
        if (gameObject.transform.localScale.x <= 0)
        {
            ballPoof = Instantiate(ballPoofPrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            Destroy(ballPoof, 1f);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&& !hasKickedBall)
        {
            hasKickedBall = true;
            Vector2 direction = ((Vector2)transform.position - (Vector2)collision.transform.position);
            direction = direction.normalized;
            rb.AddForce(direction*Force);
            outsidePathfinding.IncreaseHappiness();
            Invoke("ResetBall", 2f);
        }
    }

    private void ResetBall()
    {
        hasKickedBall=false;
    }

    private void CheckBoundaries()
    {
        Vector3 viewPos = MainCam.WorldToViewportPoint(transform.position);
        Vector2 curVelocity = rb.velocity;
        bool bounce = false;

        if ((viewPos.x <= 0.02f && curVelocity.x < 0) || (viewPos.x >= 0.98f && curVelocity.x > 0))
        {
            curVelocity.x = -curVelocity.x;
            bounce = true;
        }

        if ((viewPos.y <= 0.02f && curVelocity.y < 0) || (viewPos.y >= 0.4f && curVelocity.y > 0))
        {
            curVelocity.y = -curVelocity.y;
            bounce = true;
        }

        if(bounce)
        {
            rb.velocity = curVelocity;
        }
    }

    private void DestroyBall()
    {
        animator.SetBool("isDestroying", true);
    }
}
