using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDefense : MonoBehaviour {

	//public string attackAnimName = "attack01";
	public float attackStrength = 1f;
	public float attackRadius =10f;

	public GameObject arrowPrefab;
	float arrowCooldown = 0.5f;
	float arrowCooldownLeft = 0;
	Transform arrowTransform;

	//temp tower attack
	private bool attacking;
	private GameObject target;
	public float health = 150;

	public bool TakeDamage(float damage) {
		health -= damage;
		if (health <= 0) {
			gameObject.SetActive (false);
			return false; //not standing
		}
		return true; //still standing
	}

	void Start () {


		arrowTransform = transform.Find("Arrow");

	}

	void Update () {
		//temp tower attack
		if(attacking){ 
			target.GetComponent<Walk2> ().TakeDamage (attackStrength);
		}

//		Walk2[] enemies = GameObject.FindObjectsOfType<Walk2> ();
//
//		Walk2 nearestEnemy = null;
//		float dist = Mathf.Infinity;
//
//		foreach (Walk2 e in enemies) {
//			float d = Vector3.Distance (this.transform.position, e.transform.position);
//			if (nearestEnemy == null || d < dist) {
//				nearestEnemy = e;
//				dist = d;
//			}
//		}
//		if (nearestEnemy == null) {
//			Debug.Log ("no enemie");
//			return;
//		}
//
//		Vector3 dir = nearestEnemy.transform.position - this.transform.position;
//
//		Quaternion aimArrow = Quaternion.LookRotation (dir);
//
//
//		arrowTransform.rotation = Quaternion.Euler (0, aimArrow.eulerAngles.y, 0);
//
//		arrowCooldownLeft -= Time.deltaTime;
//		if (arrowCooldownLeft <= 0 && dir.magnitude<= attackRadius) {
//			arrowCooldownLeft = arrowCooldown;
//			Shoot(nearestEnemy);
//
//		}
//	}
//		
//		void Shoot(Walk2 e){
//			GameObject arrowGO = (GameObject)Instantiate(arrowPrefab, this.transform.position, this.transform.rotation);
//			Arrow a = arrowGO.GetComponent<Arrow>();
//			a.target = e.transform;
//			gameObject.GetComponent<Walk2> ().TakeDamage (attackStrength);
		}

	//temp tower attack cuz it works 
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Enemy") {
			attacking = true;
			target = col.gameObject;
			Debug.Log ("entered 1");
		
	
		}
	}


	
	}

