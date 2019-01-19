using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerUI : MonoBehaviour {

    public QueueTasks queueTasks;
    public GameObject taskElemUI;

    public void UpdateUI()
    {
        RemoveAllChild();
        for (int i = 0; i < queueTasks.Size(); ++i)
        {
            AddActionUI(queueTasks.Get(i));
        }
    }

    private void RemoveAllChild()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void AddActionUI(Action action)
    {
        Action.Actions actionType = action.GetAction();
        int numberAction = action.GetNumber();

        GameObject taskElemUI_t = Instantiate(taskElemUI, transform);
        UIElemSetter uiElemSetter = taskElemUI_t.GetComponent<UIElemSetter>();

        switch (actionType)
        {
            case Action.Actions.FORWARD:
                uiElemSetter.SetForwardArrow();
                break;
            case Action.Actions.LEFT:
                uiElemSetter.SetLeftArrow();
                break;
            case Action.Actions.RIGHT:
                uiElemSetter.SetRightArrow();
                break;
        }

        uiElemSetter.SetNumber(numberAction);
    }
}
