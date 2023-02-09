//using Codice.Client.BaseCommands;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public string inputID;
    float baseSpeed = 5f;
    float speedModifier = 1.0f; //Remove later
    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal" + inputID); // Get the vertical and horizontal axis
        float inputY = Input.GetAxis("Vertical" + inputID);

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
