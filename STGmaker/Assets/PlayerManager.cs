using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
	//this script should be added to the player because the mousedown
	//define the event that happens on the player then change the properties of player
	public static PlayerManager _instance;
	public static PlayerManager Instance{get{return _instance;}}

	private Vector3 _screenPoint;
	private Vector3 _offset;
	private Vector2 _playerSize;

	public GameObject _player;

	void Awake(){
		if(_instance == null){
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}else{
			DestroyImmediate(gameObject);
		}
	}

	void Start(){
		//to add some event that player need to be inform
		_playerSize.x = _player.GetComponent<Player>()._enityWidth;
		_playerSize.y = _player.GetComponent<Player>()._enityHeight;

	}
	
	void OnMouseDown(){
		_screenPoint = Camera.main.WorldToScreenPoint(_player.transform.position);
		_offset = _player.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z));
	}

	void OnMouseDrag(){
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + _offset;

		curPosition.x = Mathf.Clamp(curPosition.x,_playerSize.x/2,Global.ScreenWidth - _playerSize.x/2 );
		curPosition.y = Mathf.Clamp(curPosition.y,-Global.ScreenHeight + _playerSize.y/2, -_playerSize.y/2);
		
		_player.transform.position = curPosition;	
	}


	void ShotBullet(){

	}

	void UseBomb(){

	}


}
