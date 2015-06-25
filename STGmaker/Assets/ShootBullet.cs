using UnityEngine;
using System.Collections;

public enum SHOOT_TYPE{
	NORMAL=0,
	TYPEA =1,
	TYPEB =2,
}

public class ShootBullet : MonoBehaviour {

	private Transform _gameObjectTransform;
	public SHOOT_TYPE _type;
	public GameObject _bullet;
	public bool _isPlayer;
    public float _shootInterval = 3f;

	private float _shoottime;
	private int _movedirection;


	void Start () {
      _gameObjectTransform = gameObject.transform;
	  _shoottime = Time.time;
		if(_isPlayer){
			_movedirection = 1;// if the object is player the bullet will move up
		}else{
			_movedirection = -1;// if not the object is the enemy so move down
		}
	  
	}



	// Update is called once per frame
	void Update () {
		if((Time.time - _shoottime) > _shootInterval){
			//Debug.Log(Time.time - _shoottime);
			switch(_type){
			case SHOOT_TYPE.NORMAL:
				  Shoot_Normal();
				break;
			case SHOOT_TYPE.TYPEA:
				  Shoot_TypeA();
				break;
			case SHOOT_TYPE.TYPEB:
				break;
			default:
				break;
			}
			_shoottime = Time.time;
		}else{

		}
	}


	void Shoot_Normal(){
		Debug.Log("ShootNormal");
	}


	void Shoot_TypeA(){


	}

	void Shoot_TypeB(){

	}

}
