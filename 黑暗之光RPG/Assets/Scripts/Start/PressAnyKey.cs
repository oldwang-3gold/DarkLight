using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour {

	private bool isAnyKeyDown=false;//表示是否有任何键按下
	private GameObject buttonContainer;
	void Start() {
		buttonContainer=this.transform.parent.Find("buttonContainer").gameObject;
	}
	// Update is called once per frame
	void Update () {
		if(!isAnyKeyDown){
			if(Input.anyKey){
				//show button container
				//hide self
				ShowButton();
			}
		
		}
		
	}
	void ShowButton(){
		buttonContainer.SetActive(true);
		this.gameObject.SetActive(false);
	}
}
