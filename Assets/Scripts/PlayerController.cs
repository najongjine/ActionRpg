using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public Rigidbody2D theRB;
    private Animator anim;

    public SpriteRenderer theSR;
    public Sprite[] playerDirectionSprites;
    public Animator wpnAnim;

    private bool isKnockingBack;
    public float knockbackTime, knockbackForce;
    private float knockbackCounter;
    private Vector2 knockDir;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isKnockingBack)
        {
            /* without physics system */
            //transform.transform.localPosition = new Vector3(transform.position.x + (Input.GetAxis("Horizontal") * moveSpeed*Time.deltaTime)
            //    , transform.position.y + (Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime)
            //    , transform.position.z
            //    );

            /* with physics system */
            theRB.velocity = new Vector2(Input.GetAxis("Horizontal")
                , Input.GetAxis("Vertical")).normalized * moveSpeed;

            anim.SetFloat("Speed", theRB.velocity.magnitude);

            if (theRB.velocity != Vector2.zero)
            {
                if (Input.GetAxisRaw("Horizontal") != 0)
                {
                    theSR.sprite = playerDirectionSprites[1];
                    if (Input.GetAxisRaw("Horizontal") < 0)
                    {
                        theSR.flipX = true;
                        wpnAnim.SetFloat("dirX", -1f);
                        wpnAnim.SetFloat("dirY", 0f);
                    }
                    else
                    {
                        theSR.flipX = false;
                        wpnAnim.SetFloat("dirX", 1f);
                        wpnAnim.SetFloat("dirY", 0f);
                    }
                }
                else
                {
                    if (Input.GetAxisRaw("Vertical") < 0)
                    {
                        theSR.sprite = playerDirectionSprites[0];
                        wpnAnim.SetFloat("dirX", 0f);
                        wpnAnim.SetFloat("dirY", -1f);
                    }
                    else if (Input.GetAxisRaw("Vertical") > 0)
                    {
                        theSR.sprite = playerDirectionSprites[2];
                        wpnAnim.SetFloat("dirX", 0f);
                        wpnAnim.SetFloat("dirY", 1f);
                    }
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                wpnAnim.SetTrigger("Attack");
            }

        }
        else
        {
            knockbackCounter -= Time.deltaTime;
            theRB.velocity = knockDir * knockbackForce;
            if (knockbackCounter <= 0)
            {
                isKnockingBack = false;
            }

        }

    }

    public void knockBack(Vector3 knockerPosition)
    {
        knockbackCounter = knockbackTime;
        isKnockingBack=true;

        knockDir = transform.position - knockerPosition;
        knockDir.Normalize();
    }

}
