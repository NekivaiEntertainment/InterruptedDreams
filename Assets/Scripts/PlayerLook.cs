using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour 
{
	public Transform playerBody;
	public float mouseSensor = 2f;

	float xAxisClamp = 0;

	void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () 
	{
		RotateCamera();		
	}

	void RotateCamera()
	{
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");

		float rotateAmountX = mouseX * mouseSensor;
		float rotateAmountY = mouseY * mouseSensor;

		xAxisClamp -= rotateAmountY;

		Vector3 targetRotationCam = transform.rotation.eulerAngles;
		Vector3 targetRotationBody = playerBody.rotation.eulerAngles;

		targetRotationCam.x -= rotateAmountY;
		targetRotationCam.z = 0;
		targetRotationBody.y += rotateAmountX;

		if(xAxisClamp > 90)
		{
			xAxisClamp = targetRotationCam.x = 90;
		} 
		else if (xAxisClamp < -90)
		{
			xAxisClamp = -90;
		}

		transform.rotation = Quaternion.Euler(targetRotationCam);
		playerBody.rotation = Quaternion.Euler(targetRotationBody);
	}	
}
