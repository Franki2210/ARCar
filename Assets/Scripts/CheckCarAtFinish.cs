using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCarAtFinish : MonoBehaviour {

    public bool isFinished = false;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("ColliderEnter");
        if(other.tag == "Finish")
        {
            isFinished = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Finish")
        {
            isFinished = false;
        }
    }
}
