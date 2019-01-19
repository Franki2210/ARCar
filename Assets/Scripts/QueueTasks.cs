using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueTasks : MonoBehaviour {

    private List<Action> actions = new List<Action>();

    public void Add(Action action)
    {
        actions.Add(action);
    }

    public void Add(Action.Actions action, int number = 0)
    {
        actions.Add(new Action(action, number));
    }

    public int Size()
    {
        return actions.Count;
    }

    public bool isEmpty()
    {
        return Size() <= 0;
    }

    public Action GetLast()
    {
        if (!isEmpty())
            return actions[actions.Count - 1];
        else
            return null;
    }

    public Action PopLast()
    {
        Action action = GetLast();
        RemoveLast();
        return action;
    }

    public void RemoveLast()
    {
        if (!isEmpty())
            actions.RemoveAt(actions.Count - 1);
    }

    public Action GetFirst()
    {
        return actions[0];
    }

    public Action PopFirst()
    {
        Action action = GetFirst();
        actions.RemoveAt(0);
        return action;
    }

    public Action Get(int i)
    {
        return actions[i];
    }

    public List<Action> GetQueueTask()
    {
        return actions;
    }

    public void SetNumberInLastAction(int number)
    {
        if (!isEmpty())
        {
            actions[actions.Count - 1].SetNumber(number);
        }
        Debug.Log(actions[actions.Count - 1].GetNumber());
    }
}
