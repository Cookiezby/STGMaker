using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EVENT_TYPE{
	ENEMY_OUTOFSCREEN,
	ENEMY_KILLED,
	ENEMY_HITPLAYER,
}


public class EventManager : MonoBehaviour {

	private static EventManager instance;
	public delegate void OnEvent(EVENT_TYPE event_type, Component sender, object Param = null);

	private Dictionary<EVENT_TYPE,List<OnEvent>> Listeners = new Dictionary<EVENT_TYPE,List<OnEvent>>();


	void Awake(){
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else{
			DestroyImmediate(this);
		}

	}

	public void AddListener(EVENT_TYPE event_type,OnEvent listener){
		List<OnEvent> ListenList = null;
		// if the event_type is exist
		if (Listeners.TryGetValue(event_type, out ListenList)) {
			ListenList.Add(listener);
			return;
		}
		//if the event_type is new
		ListenList = new List<OnEvent>();
		ListenList.Add(listener);
		Listeners.Add (event_type,ListenList);

	}

	public void RemoveListener(EVENT_TYPE event_type,OnEvent listener){
		List<OnEvent> ListenList = null;
		if (Listeners.TryGetValue(event_type, out ListenList)) {
			// this event is exists
			// then find if the listener is listening this event
			if(ListenList.Contains(listener)){
				ListenList.Remove(listener);
			}

			return;


		}else{
			// the event is not exist check the name again
			return;
		}
	}

	public void AddEvent(EVENT_TYPE event_type){
		List<OnEvent> ListenList = null;
		ListenList = new List<OnEvent>();
		Listeners.Add (event_type,ListenList);
	}

	public void RemoveEvent(EVENT_TYPE event_type){
		Listeners.Remove(event_type);
	}



	public void PostNotification(EVENT_TYPE event_type,Component sender, object Param = null){

		List<OnEvent> ListenList = null;

		if (!Listeners.TryGetValue(event_type,out ListenList)) {
			return;
		}

		for(int i =0; i < ListenList.Count; i++){
			if(!ListenList[i].Equals(null)){
				ListenList[i](event_type,sender,Param);
			}
		}
	}


	public void RemoveRedundancies(){
		Dictionary<EVENT_TYPE, List<OnEvent>> TmpListeners = new Dictionary<EVENT_TYPE, List<OnEvent>>();

		foreach (KeyValuePair<EVENT_TYPE, List<OnEvent>> Item in Listeners ) {
			for (int i = Item.Value.Count-1; i>= 0;i--) {
				if(Item.Value[i].Equals(null))
					Item.Value.RemoveAt(i);
			}
			if(Item.Value.Count>0)
				TmpListeners.Add (Item.Key,Item.Value);

		}
		Listeners = TmpListeners;

	}

	void OnLevelWasLoaded(){
		RemoveRedundancies();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public static EventManager Instance{
		get{
			return instance;
		}


	}

}
