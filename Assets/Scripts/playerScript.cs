using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {

    public float speed = 10f;
    public float maxSpeed = 50f;
    public float switchSpeed = 5f;
    public float hoverForce = 65f;
    public float hoverHeight = 3.5f;

    public float jumpHeight = 10f;

    private float strafeInput;
    private Rigidbody player;
    private float doon = -0.1f;

    float xPosition = 0.0f;

     public bool grounded = false;
    public int jumpTest = 1;
    bool jump = false;

	// Use this for initialization
	void Awake () {
        player = GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && xPosition != -5f)
        {
            xPosition  = xPosition - 5f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && xPosition != 5f)
        {
            xPosition = xPosition + 5f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        // Keep floating above ground
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
            player.AddForce(appliedHoverForce, ForceMode.Acceleration);

            // Check height to see if grounded
            if (proportionalHeight < jumpTest)
            {
                grounded = true;
            } else
            {
                grounded = false;
            }
        }

        // Add a negative force in down direction to keep jellyfish bobbing.
        player.AddForce(transform.up * doon);

        // Linear Interpolate the position to smooth transition between the rails.
        player.position = Vector3.Lerp(player.position, new Vector3(xPosition, player.position.y, player.position.z), Time.deltaTime * switchSpeed);

        // Constant forward movement
        player.AddForce(transform.forward * speed);
    
        // Clamp the velocity to stop constant increase in speed.
        player.velocity = Vector3.ClampMagnitude(player.velocity, maxSpeed);


        // Jumping
        if (jump == true && grounded == true)
        {
            player.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
            jump = false;
        }
    }
}
    