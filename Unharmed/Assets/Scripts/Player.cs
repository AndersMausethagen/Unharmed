using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
	
	{
		public float maxSpeed = 200.0F;
		public float accelerationSpeed = 1.0F;
		public float currentSpeed;
		public float jumpSpeed = 15.0F;
		public float vertSpeed = 0f;
		public float gravity = 25.0F;
		private bool isMoving = false;
		private Vector2 moveDirection = Vector2.zero;
		CharacterController controller;
		GameObject maincamera;
		CameraBehaviour camerascript;
        Animator anim;





		void Start () 
	{
		controller = GetComponent<CharacterController>();
		maincamera = GameObject.FindGameObjectWithTag("MainCamera");
		camerascript = maincamera.GetComponent<CameraBehaviour>();
        anim = this.GetComponent<Animator>();
	}
	
		void Update() 
		{

		WallJump ();
		Movement ();
		CameraZoom();


		//print(moveDirection);

	}
	

	void CameraZoom()
	{
		if (moveDirection.x != 0.0f) 
		{
			isMoving = true;
		} else
			isMoving = false;
		
		if (isMoving == true) 
		{
			camerascript.cmSize = camerascript.cmSize *= 1.01f;
		}
		if (isMoving == false) 
		{
			camerascript.cmSize = camerascript.cmSize *= 0.99f;
		}
		if (camerascript.cmSize >= 40) 
		{
			camerascript.cmSize = 40;
		}
		if (camerascript.cmSize <= 30) 
		{
			camerascript.cmSize = 30;
		}

	}
	void WallJump()
	{
	//CharacterController controller = GetComponent<CharacterController>();

		if(controller.collisionFlags == CollisionFlags.Above)
		{
			print("Touching top");
			moveDirection.y = jumpSpeed *-0.5F;
		}
		if ((controller.collisionFlags & CollisionFlags.Sides)!=0)
		{

			{
			moveDirection.y = jumpSpeed *-0.5F;
			}

			
		}
		if (controller.collisionFlags == CollisionFlags.None) 
		{
			//moveDirection.x = maxSpeed;
			//controller.Move(moveDirection * Time.deltaTime);


		}
		if(controller.collisionFlags == CollisionFlags.Sides && Input.GetButton("Jump")) 
		{
			if(moveDirection.x >= 0)
			{
				moveDirection.y = jumpSpeed;
				moveDirection.x = -jumpSpeed/2;

			}
			else
			{

			moveDirection.y = jumpSpeed;
			moveDirection.x = jumpSpeed/2;
			}
			
			
		}

	}
	void Movement()
	{

	//CharacterController controller = GetComponent<CharacterController>();


		if (controller.isGrounded) 
		{
			moveDirection = new Vector2 (Input.GetAxis ("Horizontal"),0);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= maxSpeed;

			
			if (Input.GetButton("Jump"))
			{
				moveDirection.y = jumpSpeed;
				controller.Move(moveDirection * Time.deltaTime);
                anim.SetInteger("Direction", 2);
		
			}
						
		}
		float inputX = Input.GetAxis("Horizontal");
		moveDirection.x = inputX * maxSpeed;
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
	

	void Movement2()
	{
			moveDirection = new Vector2 (Input.GetAxis ("Horizontal"),0);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= maxSpeed;

		if (controller.isGrounded) 
		{
			vertSpeed = 0;
		}
		if (Input.GetButton("Jump"))
		{
		vertSpeed = jumpSpeed;
		moveDirection.y = jumpSpeed;
		//moveDirection.x = (transform.TransformDirection (moveDirection));
		controller.Move(moveDirection * Time.deltaTime);
		
		}
		//moveDirection.y -= gravity * Time.deltaTime;
		vertSpeed -= gravity*Time.deltaTime; 
		moveDirection.y = vertSpeed;
		controller.Move(moveDirection * Time.deltaTime);
		// include vertical speed // Move the controller controller.Move(moveDirection Time.deltaTime)
	}
}

	


