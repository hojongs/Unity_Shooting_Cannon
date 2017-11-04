using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactee : MonoBehaviour
{
    string myName;

    void Start ()
    {
        myName = "interactee";
	}
	
	void Update ()
    {
		
	}

    public void interact(Action lambda)
    {
        lambda();
        Debug.Log(myName);
    }
}
