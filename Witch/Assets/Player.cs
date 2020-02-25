using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    //float keyUp;
    float timeLast, timeStep = 2f;
    float holdDash, holdDashTime = .2f;
    

    //movement
    float tempVel;
    float maxVelocity = 2f;

    int dashPower = 5;
    float dashTime;
    public bool dashing;
    bool dashOnce = false;

    bool grounded = false;

    public bool jumpDouble = false;
    float jumpForce = 300f;

    cameraSmooth mainCamera;

    private Inventory inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        timeLast = Time.time;
        dashTime = Time.time;
        mainCamera = Camera.main.GetComponent<cameraSmooth>();
        inventory = new Inventory();

    }

    // Update is called once per frame
    void Update()
    {

        //FLIP CHARACTER SPRITE
        if (Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            this.transform.localScale = new Vector3(-1,1,1);
            mainCamera.left = true;
        }
        if (Input.GetAxisRaw("Horizontal") > 0.1f)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            mainCamera.left = false;
        }

        //////////////////////////////////////////// Jumping
        if (grounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
        //////////////////////////////////////////// Jumping End

        if (grounded)
        {
            //sprint or running //run to dash
            if (Input.GetButtonDown("Run"))
            {
                holdDash = Time.time;
            }

            if (Input.GetButton("Run") && dashPower > 0)
            {
                maxVelocity = 3;
                dashing = true;
            }
            else if (Input.GetButtonUp("Run") && Time.time - holdDash < holdDashTime)
            {
                //////////////////////////////////////////// Dashing
                
                

                //time limited dash
                if (Time.time - timeLast > timeStep && !dashOnce)
                {
                    if (!dashOnce)
                    {
                        timeLast = Time.time;
                        dashOnce = true;
                    }
                    timeStep = 2f;
                    maxVelocity = 50f;
                }
                if (Time.time - timeLast > timeStep && dashOnce)
                {
                    timeStep = 1f;
                    //print("reset message");
                    if (dashOnce)
                        timeLast = Time.time;
                    dashOnce = false;
                }
                //keeps dash from getting too high or low
                dashPower = Mathf.Clamp(dashPower, 0, 5);
                //////////////////////////////////////////// Dashing End
            }
            else
            {
                maxVelocity = 1;
                dashing = false;
            }

            //any movement
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                tempVel = Input.GetAxisRaw("Horizontal") * 2f * maxVelocity * Time.deltaTime;
            }

            //stop horizontal movement
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                rb.velocity = new Vector3(0f, rb.velocity.y);
                tempVel = 0;
                rb.angularVelocity = 0;
            }
        }


        if (Time.time - dashTime > 1f && dashing)
        {
            dashTime = Time.time;
            dashPower--;
            //print(dashPower);
        }
        else if (Time.time - dashTime > 1f && !dashing)
        {
            dashTime = Time.time;
            dashPower++;
            //print(dashPower);
        }


        this.transform.rotation = new Quaternion(0,0,0,0);

        this.transform.Translate(tempVel, 0, 0);

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        grounded = true;
        jumpDouble = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}
