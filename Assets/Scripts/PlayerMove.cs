using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour 
{
	CharacterController charControl;
	public float walkSpeed = 4f;

	void Awake () 
	{
		charControl = GetComponent<CharacterController>();
        Cursor.visible = false;
	}

	void Update () 
	{
		MovePlayer();
	}

	void MovePlayer()
	{
		float horiz = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");

		Vector3 moveDirectionalS = transform.right * horiz * walkSpeed;
		Vector3 moveDirectionalF = transform.forward * vert * walkSpeed;

		charControl.SimpleMove(moveDirectionalS);
		charControl.SimpleMove(moveDirectionalF);
	}
}
