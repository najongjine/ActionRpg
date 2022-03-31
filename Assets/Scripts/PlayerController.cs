using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D theRB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* without physics system */
        //transform.transform.localPosition = new Vector3(transform.position.x + (Input.GetAxis("Horizontal") * moveSpeed*Time.deltaTime)
        //    , transform.position.y + (Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime)
        //    , transform.position.z
        //    );

        /* with physics system */
        theRB.velocity = new Vector2(Input.GetAxis("Horizontal")
            , Input.GetAxis("Vertical")).normalized * moveSpeed;
    }
}
