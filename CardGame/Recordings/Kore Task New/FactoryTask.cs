using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryTask : TaskBase
{
    //public GameObject boxObj;


    protected override void RewardAfterTask()
    {
        //Custom
        TQuestManager.instance.currentTask = TQuestManager.TaskList.Completed;
        TQuestManager.instance.UpdateTaskTracker();
        TQuestManager.instance.SetCurrentTaskCode();
        TQuestManager.instance.subTaskText.text = "Task Completed";
        TQuestManager.instance.ShowSubTask();

        //regen task
        Reward();

        //disable the obj
        gameObject.SetActive(false);

        //set current task to none
        TQuestManager.instance.currentTask = TQuestManager.TaskList.None;
        TQuestManager.instance.UpdateTaskTracker();
        TQuestManager.instance.SetCurrentTaskCode();

        //set layer to interactable
        gameObject.layer = LayerMask.NameToLayer("Interactable");
        foreach (Transform child in transform)
        {
            child.gameObject.layer = LayerMask.NameToLayer("Interactable");
        }
    }
}
