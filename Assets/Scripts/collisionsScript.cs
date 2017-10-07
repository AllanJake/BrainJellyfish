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
    }
}
