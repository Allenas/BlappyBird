using UnityEngine;
using System.Collections;

/**
 * Bolun Gao

 */

public class PipeMovement : MonoBehaviour {

	private Controller controller;

	public float pipeSpeed;

	private bool getPoint;

	// Use this for initialization
	void Start () {
		controller = (Controller) FindObjectOfType(typeof(Controller));
	}

	void OnEnable(){
		getPoint = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (controller.getState () != GameStates.Playing) {
			return;
		}
	
		transform.position += new Vector3 (pipeSpeed, 0, 0) * Time.deltaTime;

		if (transform.position.x < -3.25f) {
			gameObject.SetActive (false); 
		}

		if (!getPoint && (transform.position.x + 2f)< controller.bird.position.x) {
			getPoint = true;
			controller.addPoint ();
		}
	}
}
