using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public float speed = 5f;
	public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = target.position = this.transform.localPosition;

		float distThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distThisFrame) {
			ArrowHit ();
		}
		else{
			transform.Translate (dir.normalized * distThisFrame, Space.World);
			Quaternion targetRotation = Quaternion.LookRotation (dir);
			this.transform.rotation = Quaternion.Lerp (this.transform.rotation, targetRotation, Time.deltaTime * 5);
		}
	}

	void ArrowHit() {
		Destroy (gameObject);
}
}


