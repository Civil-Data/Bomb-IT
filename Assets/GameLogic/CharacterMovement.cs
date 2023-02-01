//using Codice.Client.BaseCommands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float baseSpeed = 5f;
    float speedModifier = 1.0f; //Remove later
    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal"); // Get the vertical and horizontal axis
        float inputY = Input.GetAxis("Vertical");

        //Add calculation of currentspeed to the playerclass. This is because player speed is individual
        float currentSpeed = baseSpeed * speedModifier;

        /*
         Example on how this will look in the future

        float currentSpeed = player[].speed
         */
        Vector3 movement = new Vector3(inputX * currentSpeed, inputY * currentSpeed); //Movement with base speed, which is set to 10 here. Possible add speed modifier later.

        transform.Translate(Move(inputX, inputY, Time.deltaTime, currentSpeed));
    }
    public Vector3 Move(float h, float v, float deltaTime, float currentSpeed)
    {
        float x = h * currentSpeed * deltaTime;
        float y = v * currentSpeed * deltaTime;
        return new Vector3(x, y, 0);
    }

}
