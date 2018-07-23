using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour 
{
	CharacterController controller;
	public float walkSpeed = 4f;
    public float jumpSpeed = 8f;
    public float gravity = 9.8f;

    private Vector3 moveDirection = Vector3.zero;

	void Awake () 
	{
        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
	}

	void Update () 
	{
		MovePlayer();
	}

	void MovePlayer()
	{
        if(controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= walkSpeed;

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
	}
}
