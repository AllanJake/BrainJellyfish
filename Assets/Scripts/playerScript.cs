using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {

    public float speed = 90f;
    public float switchSpeed = 5f;
    public float hoverForce = 65f;
    public float hoverHeight = 3.5f;

    private float strafeInput;
    private Rigidbody player;

    float xPosition = 0.0f;

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

        player.position = Vector3.Lerp(player.position, new Vector3(xPosition, player.position.y, player.position.z), Time.deltaTime * switchSpeed);

        // Constant forward movement
        player.AddForce(transform.forward * speed);
    }
}
    