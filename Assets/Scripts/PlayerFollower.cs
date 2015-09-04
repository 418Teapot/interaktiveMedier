using UnityEngine;
using System.Collections;

public class PlayerFollower : MonoBehaviour {


	public float distance = 6.0f;
	public float threshold = 1.0f;
	public float camMoveSpeed = 2.0f;

	public float offsetX = 2.0f;
	public float offsetY = 2.0f;
	
	public GameObject player;

	// Use this for initialization
	void Start () {
		if(player == null)
			player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 myPos = new Vector3(transform.position.x, transform.position.y, -distance);
		Vector3 newPos = new Vector3(player.transform.position.x+offsetX, player.transform.position.y+offsetY, -distance);

		//if (transform.position.x > player.transform.position.x + threshold || transform.position.x < player.transform.position.x - threshold) {

			//Debug.Log ("We should move!");	
			transform.position = Vector3.Lerp (myPos, newPos, Time.deltaTime*camMoveSpeed);

		//}
		//transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -distance); 
	}
}
