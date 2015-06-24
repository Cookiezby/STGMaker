using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public GameObject _enemyPrefab;
	public int _updateRate;
	public float _updateFrequency;

	
	private float _startTime;
	private Vector2 _enemySize;

	void Start(){
		_startTime = Time.time;
		_enemySize = new Vector2();
		_enemySize.x = _enemyPrefab.GetComponent<Enity>()._enityWidth;
		_enemySize.y = _enemyPrefab.GetComponent<Enity>()._enityHeight;

	}

	void GenerateEnemy(){
		if(_updateRate > Random.Range(1,10)){
			Instantiate(_enemyPrefab,GeneratePosition(),Quaternion.identity);
		}
	}


	public void EnemyManagerUpdate(){
		if((Time.time - _startTime) > _updateFrequency){
			GenerateEnemy();
			_startTime = Time.time;
		}
	}

	Vector3 GeneratePosition(){
		float x = Random.Range(_enemySize.x/2,Global.ScreenWidth - _enemySize.x/2);
		float y = _enemySize.y/2;
		float z = 0;
		return new Vector3(x,y,z);
	}

	Vector3[] GeneratePosition(int amount){
		Vector3[] positions = new Vector3[amount];

		return positions;
	}// I am not sure if need to generate more than one Enemy at once


	void OnEvent(EVENT_TYPE event_type, Component sender, object Param = null){
	   
	}//this is to get the message that send to the EnemyManager
}
