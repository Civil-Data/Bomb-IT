using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float baseSpeed = 0.5f;
    float speedModifier = 0.5f; //Remove later
    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal"); // Get the vertical and horizontal axis
        float inputY = Input.GetAxis("Vertical");
        var deltaTime = Time.deltaTime; 

        //Add calculation of currentspeed to the playerclass. This is because player speed is individual
        float currentSpeed = baseSpeed * speedModifier;

        /*
         Example on how this will look in the future

        float currentSpeed = player[].speed
         */
        Vector2 movement = new Vector2(inputX * currentSpeed, inputY * currentSpeed); //Movement with base speed, which is set to 10 here. Possible add speed modifier later.
        

        transform.Translate(Move(inputX, inputY, deltaTime, currentSpeed)); // Will be called every frame);

    }

    /*
      Separated so that we can test the movement
    float h = X-axis
    float v = Y-axis
    deltaTime = time in unity
     */

    public Vector2 Move (float h, float v, float deltaTime, float currentSpeed)
    {
        float x = h * currentSpeed;
        float y = v * currentSpeed;
        return new Vector2 (x,y);
    }

}
