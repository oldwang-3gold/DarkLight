using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour {
	public GameObject[] characterPrefab;
	private GameObject[] characterGameObjects;
	private int selectedIndex=0;
	private int length;//所有可供选择的角色个数
	public Text nameInput;
	private void Start() {
		length=characterPrefab.Length;
		characterGameObjects=new GameObject[length];
		for(int i=0;i<length;i++){
			characterGameObjects[i]=GameObject.Instantiate(characterPrefab[i],transform.position,transform.rotation);
		}
		UpdateCharacterShow();
	}
	void UpdateCharacterShow(){//更新所有角色的显示
		characterGameObjects[selectedIndex].SetActive(true);
		for(int i=0;i<length;i++){
			if(i!=selectedIndex){
				characterGameObjects[i].SetActive(false);//把未选择的角色设置为隐藏
			}
		}
	}

	public void OnNextButtonClick(){//当我们点击下一个按钮
		selectedIndex++;
		selectedIndex%=length;
		UpdateCharacterShow();
	}
	public void OnPrevButtonClick(){//当我们点击上一个按钮
		selectedIndex--;
		if(selectedIndex==-1){
			selectedIndex=length-1;
		}
		UpdateCharacterShow();
	}
	public void OnOKButtonClick(){
		//加载下一个场景
		PlayerPrefs.SetInt("SelectedCharacterInde",selectedIndex);//存储选择的角色ID
		PlayerPrefs.SetString("name",nameInput.text);
	}
}
