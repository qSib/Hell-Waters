using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsKeeper : MonoBehaviour
{
    public static OptionsKeeper instance;
    public bool vrEnabled;

    void Awake()
    {
        if (instance == null) //Makes sure there's only one instance of this script.
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        vrEnabled = false; //Defaults to VR disabled.
    }

    void Update()
    {
        
    }
}
