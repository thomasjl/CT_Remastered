using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public bool canGo;
    public GameObject nextTarget;

    public bool getCanGo()
    {
        return canGo;
    }

    public void setCanGo(bool b)
    {
        canGo = b;
    }
	
}
