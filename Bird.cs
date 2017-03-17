using UnityEngine;
using System.Collections;

/**
 * Bolun Gao

 */ 

public class Bird : MonoBehaviour {

	private float animationTimer;
	public Transform bird;
	private Animator birdAnimation;

	private Controller controller;

	public Vector2 force;

	private Vector3 startAngle;


	// Use this for initialization
	void Start () {
		startAngle = bird.eulerAngles; 
		controller = (Controller) FindObjectOfType(typeof(Controller));

	}

	// Update is called once per frame
	void Update () {
		if (controller.getState () != GameStates.GameOver 
			&& controller.getState() == GameStates.Playing && 
			(Input.GetMouseButtonDown(0) || Input.GetKeyDown (KeyCode.Space))
			&& controller.getState () != GameStates.ReadyToPlay) {

			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			GetComponent<Rigidbody2D>().AddForce(force);

		}

		else if(Input.GetMouseButtonDown(0) || Input.GetKeyDown (KeyCode.Space)){
			controller.toPlay();
		}

		if (controller.getState () != GameStates.Playing && 
			controller.getState () != GameStates.GameOver) {

			GetComponent<Rigidbody2D> ().gravityScale = 0;
			return;

		}else {
			GetComponent<Rigidbody2D>().gravityScale = 1;
		}

		if(controller.getState() == GameStates.Playing ){


			if (GetComponent<Rigidbody2D> ().velocity.y > 0) {
				bird.eulerAngles += new Vector3 (0, 0, 2f);

				if (bird.eulerAngles.z > 45) {
					bird.eulerAngles = new Vector3 (0, 0, 45);
				}

			}else if (GetComponent<Rigidbody2D> ().velocity.y < 0) {
				bird.eulerAngles -= new Vector3 (0, 0, 4f);

				if (bird.eulerAngles.z < 315 && bird.eulerAngles.z > 45) {
					bird.eulerAngles = new Vector3 (0, 0, 315);
				}
			}

		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		controller.gameOver(); 

		bird.eulerAngles = startAngle; 


	}
}
