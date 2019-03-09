using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
	private Animation anim;
    private PlayerDir move;
	
	void Start(){
		anim=GetComponent<Animation>();
	    move = GetComponent<PlayerDir>();
	}
	// Update is called once per frame
	void LateUpdate () {
		if(move.playerState == PlayerState.Moving)
		{
		    PlayAnim("Run");
		}else if (move.playerState == PlayerState.Idle)
		{
		    PlayAnim("Idle");
		}
	}
	void PlayAnim(string animName){
		anim.CrossFade(animName);
	}
	
}
