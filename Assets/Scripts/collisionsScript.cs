using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionsScript : MonoBehaviour {

    public bool red = false;
    public bool blue = false;
    public bool green = false;
    public bool mystery = false;

    //detect collisions with triggers
    void OnTriggerEnter(Collider other)
    {
        //movement boundaries
        if (other.CompareTag("redBox"))
            red = true;

        if (other.CompareTag("blueBox"))
            blue = true;

        if (other.CompareTag("greenBox"))
            green = true;

        if (other.CompareTag("mysteryBox"))
            mystery = true;

        if (other.CompareTag("startCol"))
        {
            Debug.Log("We Hit the thing");
            transform.position = new Vector3(transform.position.x, transform.position.y, -2490.0f);

        }
    }
}
