using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContainer : MonoBehaviour {

	//1 游戏数据的保存 和场景之间游戏数据的传递使用PlayerPrefs
	//2.场景的分类
		//2.1开始场景
		//2.2角色选择界面
		//2.3游戏玩家打怪的界面 游戏实际运行场景


	//开始新游戏	
	public AudioSource audio;
	private void Start() {
		audio=GetComponent<AudioSource>();
	}
	public void OnStartGame(){
		PlayerPrefs.SetInt("DataFromSave",0);
		audio.Play();
		//加载选择角色场景2
	}
	public void OnLoadGame(){
		PlayerPrefs.SetInt("DataFromSave",1);//DataFromSave表示数据来自保存
		audio.Play();
		//加载我们的Play场景3
	}
}
