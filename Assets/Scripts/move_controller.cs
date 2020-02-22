using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class move_controller : MonoBehaviour
{
    public Animator anim;
    public Transform tran;
    public Rigidbody rb;
    public float speed = 5;
    public float jump = 5;
    int boostHash = Animator.StringToHash("boost");
    bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");
        float runSpeed = speed * 2;

        if (grounded && Input.GetKeyDown(KeyCode.Space))

        {
            rb.velocity = Vector3.up * jump;
        }

        if (movement != 0)
        {
            float y = (movement < 0) ? -90 : 90;
            Vector3 newRotation = new Vector3(0, y, 0);
            tran.eulerAngles = newRotation;

            grounded = Vector3.Dot(rb.velocity, Vector3.up) < .01;

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                anim.SetTrigger("boost");
                rb.velocity = new Vector3(movement * runSpeed, rb.velocity.y, rb.velocity.z);
            }
            else
            {
                rb.velocity = new Vector3(movement * speed, rb.velocity.y, rb.velocity.z);
            }

            
        }
        else
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
        }

        anim.SetFloat("speed", movement);
   
    }
}
