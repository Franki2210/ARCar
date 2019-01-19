using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
    public GameObject car;
    public ControllerUI taskControllerUI;

    public QueueTasks queueTasks;

    public GameObject finishObject;
    private Transform cellWithFinish;

    public Transform roadObject;

    private float exp = 0.01f;

    public float moveSpeed = 0.1f;
    public float rotateSpeed = 50f;

    private Vector3 carNewPosition;

    public bool move = false;

    public GameObject ButtonStart;

    public GameObject endGameWinPanel;
    public GameObject endGameLosePanel;

    private void Start()
    {
        carNewPosition = car.transform.position;
        PlaceFinishInRandomCell();
    }

    private void Update()
    {
        if (move)
        {
            if (!IsArrive(carNewPosition, car.transform.position))
            {
                car.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            else
            {
                bool nextAction = SetNextAction();
                if (!nextAction)
                {
                    move = false;
                    if(CheckFinish())
                    {
                        endGameWinPanel.SetActive(true);
                    }
                    else
                    {
                        endGameLosePanel.SetActive(true);
                    }
                }
            }
        }        
    }

    public void ReloadLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void StartMove()
    {
        move = true;
    }

    private bool CheckFinish()
    {
        float xf = finishObject.transform.position.x;
        float zf = finishObject.transform.position.z;

        float xc = car.transform.position.x;
        float zc = car.transform.position.z;

        float offset = 0.2f;

        if (xc > xf - offset && xc < xf + offset &&
            zc > zf - offset && zc < zf + offset)
            return true;
        else
            return false;

    }

    private void PlaceFinishInRandomCell()
    {
        int cellCount = roadObject.childCount;
        int randCell = Random.Range(0, cellCount - 1);
        cellWithFinish = roadObject.GetChild(randCell);
        finishObject = Instantiate(finishObject, cellWithFinish);
    }

    public bool ObjectAtFinish(Transform obj)
    {
        if (obj.position == finishObject.transform.position)
            return true;
        return false;
    }

    private bool IsArrive(Vector3 target, Vector3 pos)
    {
        return pos.x > target.x - exp && pos.x < target.x + exp &&
                pos.z > target.z - exp && pos.z < target.z + exp;
    }

    public void UpdateUI()
    {
        taskControllerUI.UpdateUI();
    }

    public void MoveForward()
    {
        queueTasks.Add(Action.Actions.FORWARD, 1);
        UpdateUI();
    }

    public void MoveLeft()
    {
        queueTasks.Add(Action.Actions.LEFT);
        UpdateUI();
    }

    public void MoveRight()
    {
        queueTasks.Add(Action.Actions.RIGHT);
        UpdateUI();
    }

    public void Stop()
    {
        ButtonStart.SetActive(true);
    }

    public void One()
    {
        if (queueTasks.GetLast().GetAction() == Action.Actions.FORWARD)
        {
            queueTasks.SetNumberInLastAction(1);
            UpdateUI();
        }
    }

    public void Two()
    {
        if (queueTasks.GetLast().GetAction() == Action.Actions.FORWARD)
        {
            queueTasks.SetNumberInLastAction(2);
            UpdateUI();
        }
    }

    public void Five()
    {
        if (queueTasks.GetLast().GetAction() == Action.Actions.FORWARD)
        {
            queueTasks.SetNumberInLastAction(5);
            UpdateUI();
        }
    }

    public void RemoveLastAction()
    {
        queueTasks.RemoveLast();
        UpdateUI();
    }

    public bool SetNextAction()
    {
        if(!queueTasks.isEmpty())
        {
            Vector3 forward = car.transform.forward / 2;
            Vector3 right = car.transform.right / 2;
            Vector3 left = -car.transform.right / 2;

            Vector3 newPosition = new Vector3();

            Action action = queueTasks.PopFirst();
            Action.Actions typeAction = action.GetAction();
            int numberAction = action.GetNumber();

            UpdateUI();

            switch (typeAction)
            {
                case Action.Actions.FORWARD:
                    carNewPosition = car.transform.position + forward * numberAction;
                    break;
                case Action.Actions.LEFT:
                    newPosition = car.transform.position + left;
                    car.transform.LookAt(newPosition);
                    carNewPosition = car.transform.position;
                    break;
                case Action.Actions.RIGHT: 
                    newPosition = car.transform.position + right;
                    car.transform.LookAt(newPosition);
                    carNewPosition = car.transform.position;
                    break;
            }
            return true;
        }
        else
        {
            return false;
        }
        
    }
}