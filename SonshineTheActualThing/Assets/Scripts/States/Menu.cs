﻿using UnityEngine;
using System.Collections;

public class Menu : StateTemplate
{

    public override void Start()
    {
        base.Start();
    }

    public override StateTemplate Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) == true)
        {
            return GetState("Level1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) == true)
        {
                return GetState("Level2");
        }
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Application.Quit();
            return GetState("MainMenu");
        }
        
        return this;
    }
}
