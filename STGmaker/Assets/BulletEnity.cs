using UnityEngine;
using System.Collections;

public class BulletEnity : Enity {

	public float _damage;
	
	void Update(){

	}

	void Move(){
		transform.Translate(Vector3.down*Time.deltaTime*_moveSpeed);
	}

	void MoveTrace(GameObject target){

	}

}
