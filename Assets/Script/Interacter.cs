using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour
{
    public Interactee interactee;
    //GameObject interactee;
    string myName;

    void Start()
    {
        Debug.Assert(interactee);
        myName = "interacter";

        interactee.interact(() =>
        {
            Debug.Log(myName);
        });

        //interactee.SendMessage("interact", () =>
        //{
        //    // body
        //});
    }

    void Update()
    {
    }
}
