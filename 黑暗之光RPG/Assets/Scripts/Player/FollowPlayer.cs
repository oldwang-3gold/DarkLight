using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;

    private Vector3 offset;

    private float distance=0;

    public float scrollSpeed = 1f;
	// Use this for initialization
	void Start()
	{
	    player = GameObject.FindGameObjectWithTag(Tags.player).transform;
	    transform.LookAt(player);
	    offset = transform.position - player.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    transform.position = offset + player.position;
        //处理视野的拉近和拉远效果
	    ScrollView();

	}

    void ScrollView()//原理：先求出相机与人物向量之差 然后求两者之间距离  求出后根据鼠标滚轮移动
                     //改变此距离并且限制在一定范围内 最后将两者之间的向量更改为原向量的单位向量乘以距离即可
    {
        //向后拉远视野，向前拉近视野
        float changeDis =-Input.GetAxis("Mouse ScrollWheel");
        distance = offset.magnitude;
        distance += changeDis * scrollSpeed;
        distance = Mathf.Clamp(distance, 2, 18);//限制distance在2-18之间
        offset = offset.normalized * distance;//先求得offset的单位向量 再乘以长度
    }
}
