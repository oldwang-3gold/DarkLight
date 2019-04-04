using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public  enum PlayerState{
	Moving,
	Idle
}
public class PlayerDir : MonoBehaviour {
   
    private bool isMouseClick=false;//表示鼠标是否放下
	public GameObject effect_click_prefab;
	private Vector3 targetPosition=Vector3.zero;
	public float speed=3f;
	private float distance;
	private CharacterController characterController;
	public PlayerState playerState=PlayerState.Idle;
    private bool isMoved;//人物移动控制


    private void Start() {
		targetPosition=transform.position;//默认目标位置为人物位置
		characterController=transform.GetComponent<CharacterController>();
    }
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)&&!EventSystem.current.IsPointerOverGameObject()){
			Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;
			bool isCollider=Physics.Raycast(ray,out hitInfo);
			if(isCollider &&hitInfo.collider.tag==Tags.ground){
                
				ShowClickEffect(hitInfo.point);
				targetPosition=hitInfo.point;
                isMouseClick = true;
			}
		}

	    if (Input.GetMouseButtonUp(0))
	    {
            isMouseClick = false;
	    }
		if(isMouseClick){
			//得到要移动的目标位置
			//让主角朝向目标位置
			targetPosition=new Vector3(targetPosition.x,transform.position.y,targetPosition.z);//使Y轴与人物一样
			transform.LookAt(targetPosition);
        }
		else
		{
		    if (isMoved)
		    {
		        transform.LookAt(targetPosition);
            }
		    
		}
	}
	private void FixedUpdate() {
		Move();
	}
	void ShowClickEffect(Vector3 hitpoint){
		GameObject.Instantiate(effect_click_prefab,hitpoint,Quaternion.identity);
	}
	void Move(){
		distance=Vector3.Distance(targetPosition,transform.position);
		if(distance>0.1f){
			playerState= PlayerState.Moving;
			characterController.SimpleMove(transform.forward*speed);
            isMoved = true;
		}else{
			playerState=PlayerState.Idle;
            isMoved = false;
		}
	}
}
