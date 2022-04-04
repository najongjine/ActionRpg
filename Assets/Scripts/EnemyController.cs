using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public Animator anim;
    public BoxCollider2D area;

    public float moveSpeed;
    public float waitTime, moveTime;
    private float waitCounter, moveCounter;

    private Vector2 moveDir;
    // Start is called before the first frame update
    void Start()
    {
        waitCounter = Random.Range(waitTime*.75f, waitTime * 1.25f);
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
                moveCounter = Random.Range(moveTime*.75f,moveTime*1.25f);
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
                waitCounter = Random.Range(waitTime * .75f, waitTime * 1.25f);
                anim.SetBool("moving", false);
            }
        }

        transform.position=new Vector3(Mathf.Clamp(transform.position.x,area.bounds.min.x+1f,area.bounds.max.x-1f)
            , Mathf.Clamp(transform.position.y, area.bounds.min.y + 1f, area.bounds.max.y - 1f)
            , transform.position.z);

    }
}
