using UnityEngine;
using System.Collections;

public class fitsLawTest : MonoBehaviour {

	public InputDevice inputDevice;
	public float sensitivity = 0.10f;
	public Material activeMaterial;
	public Material inactiveMaterial;

	public int clicksPrTrial = 10;
	public int numberOfTrials = 3;

	private int trialNumber = 0;
	private float cursorPos = 0;
	private float targetWidth = 1;
	private GameObject leftTarget;
	private GameObject rightTarget;
	private GameObject cursor;
	private GameObject active;

	private Vector3 startPos;

	private string namingConvention;
	private int tmpClicks;

	void Start(){
		leftTarget = GameObject.Find ("LeftTarget");
		rightTarget = GameObject.Find ("RightTarget");
		cursor = GameObject.Find ("Cursor");

		int obj = Random.Range (1, 3);

		if (obj == 1) {
			active = leftTarget;
		} else if (obj == 2) {
			active = rightTarget;
		}
		setActive (active);	
		StartTrial ();
		namingConvention = "trial-" + System.DateTime.Today;
	}



	// Update is called once per frame
	void Update () {

		if (trialNumber > numberOfTrials) {
			Debug.Log ("Trials are over!");
		} else if(tmpClicks > clicksPrTrial && trialNumber < numberOfTrials) {
			EndTrial();
			StartTrial();
		} else {

			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		

			if (inputDevice == InputDevice.Mouse) {
				float movement = Input.GetAxis ("Mouse X");
				cursorPos += movement * sensitivity;

				if (Input.GetButtonDown ("Fire1")) {
					RaycastHit hit;
					if (Physics.Raycast (cursor.transform.position, Vector3.forward, out hit, 10.0f)) {
						Debug.Log ("HIT: " + hit.collider.name);
					}

					tmpClicks++;
				}
			
			}

			cursor.transform.position = new Vector3 (cursorPos, 0f, 0f);



		}
	}

	public enum InputDevice{
		Mouse, Joystick
	}
	
	public void setActive(GameObject activate){
		leftTarget.GetComponent<MeshRenderer> ().material = inactiveMaterial;
		rightTarget.GetComponent<MeshRenderer> ().material = inactiveMaterial;
		activate.GetComponent<MeshRenderer> ().material = activeMaterial;
	}

	void switchActive(){
		if (active.Equals (leftTarget)) {
			setActive (rightTarget);
		} else if (active.Equals (rightTarget)) {
			setActive (leftTarget);
		}
	}

	private float tmpID;
	private float tmpD;
	private float tmpW;

	public void StartTrial(){
		trialNumber++;

		Debug.Log ("Trial #" + trialNumber + " - Started on "+System.DateTime.Now);
		float w = targetWidth;
		float d = Mathf.Abs(leftTarget.transform.position.x)+rightTarget.transform.position.x;
		float ID = Mathf.Log ((2 * d) / w, 2);
		Debug.Log ("ID: "+ID);

		tmpID = ID; tmpD = d; tmpW = w;
		tmpClicks = 0;
	}

	public void EndTrial(){
		// trial has ended! save results! :D
		Debug.Log ("Saving to file: " + namingConvention + "-trial-" + trialNumber+".txt");
	}
}
