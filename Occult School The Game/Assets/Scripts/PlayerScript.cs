using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//WILL BE COMBINE WITH PLAYER.CS BECAUSE IT IS DOABLE.

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance; 
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
