using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
	
	public float gravity = 25.0f;
	public float jumpForce = 15.0f;

	public float maxSpeed = 10.0f;
	private float moveSpeed = 3.0f;

	private Rigidbody2D rbody;
	private int jumpCount = 0;
	private bool isGrounded = true;
	private float defaultMoveSpeed;

	private float direction;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		defaultMoveSpeed = moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {

		// every frame we should get the value of 
		//horizontal axis and apply it to our object
		//Debug.Log ("axis: " + Input.GetAxis ("Horizontal"));
			
		if (Input.GetAxis ("Horizontal") != 0 && moveSpeed < maxSpeed) {
			moveSpeed = moveSpeed + 0.5f;
		} else if (Input.GetAxis ("Horizontal") == 0) {
			moveSpeed = 0;
		} else if (isGrounded) {
			moveSpeed = moveSpeed + 0.2f;
		}

		direction = Input.GetAxis ("Horizontal") * moveSpeed;

		rbody.velocity = new Vector2 (direction, -gravity*Time.deltaTime+rbody.velocity.y);

		if (Input.GetButtonDown ("Jump")) {
			if(isGrounded || jumpCount < 2){
			//Debug.Log ("Jumpin'!");
			jumpCount++;
			rbody.AddForce(Vector2.up*gravity*jumpForce);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag.Equals ("Ground")) {
			//Debug.Log("Im on the ground now!");
			jumpCount = 0;
			isGrounded = true;
			moveSpeed = defaultMoveSpeed;
		}
	}

	void OnCollisionExit2D(Collision2D c){
		if (c.gameObject.tag.Equals ("Ground")) {
			//Debug.Log("Im off the ground!");		
			isGrounded = false;
			moveSpeed = moveSpeed*0.5f;
		}
	}


}
