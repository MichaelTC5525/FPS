using UnityEngine;
using System.Collections;

public class GunFollow : MonoBehaviour {

    //Private variables can only be accessed from within the Behaviour script in the Integrated Development Environment.
    private Vector3 offset;

    //Public variables can be altered inside the Unity Editor. 
    public GameObject player;

    // Use this for initialization
    void Start () {
        //Set the distance from the camera to the player as a variable.
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        //Change the weapon's position according to the player's movement, so it keeps the same place in relation to the player GameObject.
        transform.position = player.transform.position + offset;
    }
}
