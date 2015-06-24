using UnityEngine;
using System.Collections;

public class Enemy_Name : Enity{

	public float _health;
	
	void Update () {
	   if(OutOfScreen()){
			Destroy(gameObject);
	    }
	    Move();
	}
	
	void Move(){
		transform.Translate(Vector3.down*Time.deltaTime*_moveSpeed);
	}

	bool OutOfScreen(){
		bool result = false;
		if(transform.position.y < -(Global.ScreenHeight + _enityHeight/2)){
			result = true;
		}
		return result;
	}

}
