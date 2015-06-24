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
		_enemySize.x = _enemyPrefab.GetComponent<EnemyEnity>()._enityWidth;
		_enemySize.y = _enemyPrefab.GetComponent<EnemyEnity>()._enityHeight;

	}

	void GenerateEnemy(){
		if(_updateRate > Random.Range(1,10)){
			Instantiate(_enemyPrefab,GeneratePosition(),Quaternion.identity) as GameObject;
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

	}
