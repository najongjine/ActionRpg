using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public Animator anim;

    public float moveSpeed;
    public float waitTime, moveTime;
    private float waitCounter, moveCounter;

    private Vector2 moveDir;
    // Start is called before the first frame update
    void Start()
    {
        waitCounter = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitCounter > 0)
        {
            waitCounter = waitCounter - Time.deltaTime;
            theRB.velocity = Vector2.zero;
            if (waitCounter <= 0)
            {
                moveCounter = moveTime;
                anim.SetBool("moving",true);
                moveDir=new Vector2 (Random.Range(-1f,1f), Random.Range(-1f, 1f));
                moveDir.Normalize();
            }
        }
        else
        {
            moveCounter -= Time.deltaTime;
            theRB.velocity = moveDir * moveSpeed;
            if (moveCounter<=0)
            {
                waitCounter = waitTime;
                anim.SetBool("moving", false);
            }
        }

    }
}
