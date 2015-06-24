using UnityEngine;
using System.Collections;

public class EnemyManager_Name : EnemyManager {

	public static EnemyManager_Name _instance;
	public static EnemyManager_Name Instance{get{return _instance;}}
	void Awake(){
		if(_instance == null){
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}else{
			DestroyImmediate(gameObject);
		}
	}

	void Update(){
		EnemyManagerUpdate();
	}


}
