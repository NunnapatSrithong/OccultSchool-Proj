using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override string GetDescription()
    {
        return "The door to somewhere";
    }

    public override void Interact()
    {
        //Load the new scene;
    }
}
