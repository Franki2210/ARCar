using UnityEngine;

public class Action {

    public enum Actions { FORWARD, LEFT, RIGHT, STOP };

    Actions action;
    int number;

    public Action(Actions action, int number = 0)
    {
        this.action = action;
        this.number = number;
    }

    public void SetNumber(int number)
    {
        this.number = number;
        Debug.Log("setNumber");
    }

    public Actions GetAction()
    {
        return action;
    }

    public int GetNumber()
    {
        return number;
    }
}
