using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ActionTracker : MonoBehaviour, ITrackableEventHandler
{

    public enum ImageTargetType
    {
        LEFT, RIGHT, FORWARD,
        STOP,
        ONE, TWO, FIVE
    }
    public ImageTargetType imageTargetType;

    private TrackableBehaviour mTrackableBehaviour;
    public GameManager manager;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
            SendToGameManager();
        }
    }

    private void SendToGameManager()
    { 
        switch (imageTargetType)
        {
            case ImageTargetType.LEFT:
                manager.MoveLeft();
                break;
            case ImageTargetType.RIGHT:
                manager.MoveRight();
                break;
            case ImageTargetType.FORWARD:
                manager.MoveForward();
                break;
            case ImageTargetType.ONE:
                manager.One();
                break;
            case ImageTargetType.TWO:
                manager.Two();
                break;
            case ImageTargetType.FIVE:
                manager.Five();
                break;
            case ImageTargetType.STOP:
                manager.Stop();
                break;
        }
    }
}
