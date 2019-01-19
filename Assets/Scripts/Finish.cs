using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

    public bool isFinished = false;

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Finish")
        {
            isFinished = true;
        }
    }
}
