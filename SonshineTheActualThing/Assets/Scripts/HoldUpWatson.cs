﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Jacob Connelly
/// Date Created: 19/8/14
/// Last Updated: 27/10/14
/// Description:
/// This class serves as the action of the parent lifting up the child
/// It Does this by increasing the base offset of the childs nav mesh 
/// </summary>

public class HoldUpWatson : MonoBehaviour {

	// Use this for initialization
    public Watson m_TheChild;
    float fOriginalBaseOffset;
    float fLiftRate;
    float fDropRate;

    float fMaxOffset;
    bool isPressed;

	void Start () {
        isPressed = false;

        fOriginalBaseOffset = m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset;
        fMaxOffset = fOriginalBaseOffset + 2;
        fLiftRate = 1.5f;
        fDropRate = 4.0f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isPressed = true;
            m_TheChild.bHeldUp = true;

        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            isPressed = false;
            m_TheChild.bHeldUp = false;
        }

        if (m_TheChild.bTethered)
        {
            Lift();
                  }
        else // fix when holdingthe child then letting go causes him to float
        {
            if (m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset > fOriginalBaseOffset)
                m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset -= fDropRate * Time.deltaTime;
            if (m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset < fOriginalBaseOffset)
                m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset = fOriginalBaseOffset;
         }
	}
    public void Lift()
    {
        // if the e key is pressed increase the base offset
       
      
        if (isPressed)
        {
            if (m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset < fMaxOffset)
                m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset += fLiftRate * Time.deltaTime;
        }
        else
        {
            if (m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset > fOriginalBaseOffset)
                m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset -= fDropRate * Time.deltaTime;
            if (m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset < fOriginalBaseOffset)
                m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset = fOriginalBaseOffset;
        }
       
            
    }

}
