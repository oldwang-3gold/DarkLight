using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Bar_NPC : NPC
{

    public Image quest;
    public Text quest_text;
    public GameObject accept;
    public GameObject ok;
    public GameObject cancel;
    public int killcount = 0;
    private bool isInTask = false;//默认没有接受任务
   // private Vector3 transToTarget;
    private PlayerStatus status;
    void Start()
    {
        status = GameObject.FindWithTag(Tags.player).GetComponent<PlayerStatus>();
        //  transToTarget = quest.transform.localPosition;
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isInTask)
            {
                ShowTaskInfo();
            }
            else
            {
                ShowExcuteTaskInfo();
            }
            ShowQuest();
        }
       
    }

    void ShowQuest()
    {
        quest.enabled = true;
        quest.rectTransform.DOLocalMoveX(620, 0.5f);
    }

    public void OnClickClose()
    {
        CloseQuest();
    }
    void CloseQuest()
    {
        quest.rectTransform.DOLocalMoveX(1250, 0.5f);      
    }

    void ShowTaskInfo()
    {
        quest_text.text="任务:\n杀死10只小狼\n\n奖励:\n1000金币";
        accept.SetActive(true);
        cancel.SetActive(true);
        ok.SetActive(false);
    }
    void ShowExcuteTaskInfo()
    {
        quest_text.text = "任务:\n已杀死" + killcount + "\\10只小狼\n\n奖励:\n1000金币";
        accept.SetActive(false);
        cancel.SetActive(false);
        ok.SetActive(true);
    }
    public void OnAcceptButtonClick()
    {
        isInTask = true;
        
        ShowExcuteTaskInfo();
    }

    public void OnOkButtonClick()
    {
        if (killcount >= 10)
        {
            status.GetCoin(1000);
            killcount = 0;
            ShowTaskInfo();
            //TODO 已经完成
        }
        else
        {
            CloseQuest();
            //TODO还需要杀死很多
        }
    }

    public void OnCancelButtonClick()
    {
        CloseQuest();
    }
}
