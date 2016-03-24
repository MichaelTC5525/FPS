using UnityEngine;
using System.Collections;

public class CameraFPS : MonoBehaviour {

    //Private variables can only be accessed from within the Behaviour script in the Integrated Development Environment.
    private Vector3 offset;

    //Public variables can be altered inside the Unity Editor. 
    public GameObject player;
    public GameObject m_Camera;

    // Use this for initialization
    void Start () {
        //Set the distance from the camera to the player as a variable.
        offset = transform.position - player.transform.position;
    }

    // Using LateUpdate ensures the player has moved before updating.
    void LateUpdate () {
        //Change the camera's position according to the player's movement, so it keeps the same place in relation to the player GameObject.
        transform.position = player.transform.position + offset;
		
    }

    // Call the look-around function in FixedUpdate for a regular interval.
    void FixedUpdate()
    {
        Perspective();

        //Clamp maximum and minimum values for looking up and down using the stored variable.
        float upDown = transform.eulerAngles.x;
        if (upDown >= 60f)
        {
            upDown = 60f;
        }
        else if (upDown <= 300f)
        {
            upDown = 300f;
        }
    }

    void Perspective() {
        //Call the functions responsible for the camera view movement.
        MouseHorizontal();
        MouseVertical();
    }

    void MouseHorizontal()
    {
        float lookHorizontal = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, lookHorizontal, Space.World);  //Global y-axis rotation will be level, no matter how high or low the player is looking from.
    }

    void MouseVertical()
    {
        //Use transform.eulerAngles to use Degrees, as transform.rotation is stored as a Quaternion.
        float lookVertical = Input.GetAxis("Mouse Y");
        //Allow rotation on the local x-axis.
        transform.Rotate(Vector3.right, lookVertical, Space.Self);
    }
}
