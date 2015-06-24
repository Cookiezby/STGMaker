using UnityEngine;
using System.Collections;

public enum SHOOT_TYPE{
	NORMAL=0,
	TYPEA =1,
	TYPE2 =2,
}

public class ShootBullet : MonoBehaviour {

	private Transform _gameObjectTransform;
	public SHOOT_TYPE _type;

	void Start () {
      _gameObjectTransform = gameObject.transform;
	}



	// Update is called once per frame
	void Update () {
	
	}
}
