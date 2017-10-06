using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {

    public float speed = 90f;
    public float turnSpeed = 5f;
    public float hoverForce = 65f;
    public float hoverHeight = 3.5f;

    private float strafeInput;
    private Rigidbody player;

	// Use this for initialization
	void Awake () {
        player = GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void Update () {

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
        }

        float currentX = transform.position.x;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            if (currentX == 0.0f)  // Center
            {
                while (currentX != -1.0)
                {
                    player.AddForce(-transform.right * 2);
                }
                //player.MovePosition(new Vector3(-1.0f, transform.position.y, transform.position.z));
            }

            if (currentX == 1.0f)  // Right
            {
                while (currentX != 0.0)
                {
                    player.AddForce(-transform.right * 2);
                }
                //player.MovePosition(new Vector3(0.0f, transform.position.y, transform.position.z));
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (currentX == 0.0f)  // Center
            {
                while (currentX != 1.0)
                {
                    player.AddForce(transform.right * 2);
                }
                //player.MovePosition(new Vector3(1.0f, transform.position.y, transform.position.z));
            }

            if (currentX == -1.0f)  // Left
            {
                while (currentX != 0.0)
                {
                    player.AddForce(transform.right * 2);
                }
                //player.MovePosition(new Vector3(0.0f, transform.position.y, transform.position.z));
            }
        }

        // Constant forward movement
        player.AddForce(transform.forward * speed);
    }
}
