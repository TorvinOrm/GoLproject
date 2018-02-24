using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpForce;

	private Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Walk ()
	//Horizontal movement, checked every frame
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		// Get the A and D input
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);

		rb.AddForce (movement * speed);
		// And add some horizontal speed
	}
	void Jump ()
	//Jumping. Should be not moving vertically (not falling or jumping) to jump
	{
		float moveVertical = Input.GetAxis ("Vertical");
		//Get the W and S input
		Vector3 vmovement = new Vector3 (0.0f, 0.0f, moveVertical); 
			if (Mathf.Abs(rb.velocity.y) <= 1)
			//Check if object is moving vertically
			rb.AddForce(vmovement * jumpForce);
			// Make it jump
	}
}