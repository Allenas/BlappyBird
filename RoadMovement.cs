using UnityEngine;
using System.Collections;

public class RoadMovement : MonoBehaviour {


	public float roadSpeed;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		transform.position += new Vector3 (roadSpeed * Time.deltaTime, 0, 0);

		if (transform.position.x < -3.3f) {
			gameObject.SetActive (false); 
		}
	}
}
