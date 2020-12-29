// Import general libraries for Unity Engine
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Public class to translate XR rigid camera across 2D-plane
public class MoveCamera : MonoBehaviour
{
	// Create game object for camera rig
	GameObject cameraModifier;

    // Start is called before the first frame update
    void Start()
    {
        // Find camera rig object (XRRig on Unity's XR Plugin) and assign to game object
        cameraModifier = GameObject.Find("XRRig");
    }

    // Update is called once per frame
    void Update() {}

    // This function is invoked when a line of data is received from the serial device (COM4, 9600).
    void OnMessageArrived(string msg)
    {
    	Debug.Log("Moving at speed: " + msg);			// Debug message for Unity console
    	float speed = 5f;								// Define translational speed

    	// Obtain yaw angle from XR camera orientation to use on local translational axis
    	Quaternion headYaw = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y,0);

    	// If message reads "A" translate right on local axis
    	if (msg.Equals("A"))
    	{
    		cameraModifier.gameObject.transform.Translate(headYaw*Vector3.right * Time.deltaTime * speed);
		}

		// If message reads "B" translate forward on local axis
		else if(msg.Equals("B"))
		{
			cameraModifier.gameObject.transform.Translate(headYaw*Vector3.forward * Time.deltaTime * speed);
		}

		// If message reads "C" translate backwards on local axis
		else if(msg.Equals("C"))
		{
			cameraModifier.gameObject.transform.Translate(headYaw*Vector3.back * Time.deltaTime * speed);
		}

		// If message reads "D" translate left on local axis
		else if(msg.Equals("D"))
		{
			cameraModifier.gameObject.transform.Translate(headYaw*Vector3.left * Time.deltaTime * speed);
		}
	}

	// Invoked when a connect/disconnect event occurs. The parameter 'success'
	// will be 'true' upon connection, and 'false' upon disconnection or
	// failure to connect.
    void OnConnectionEvent(bool success)
    {
    	Debug.Log(success ? "Device connected" : "Device disconnected");
	}
}