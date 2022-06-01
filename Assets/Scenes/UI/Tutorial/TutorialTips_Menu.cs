using UnityEngine;
using System;

public class TutorialTips_Menu : MonoBehaviour
{
    [Header("Movement")]
    public GameObject movementTipMenu;
    public GameObject movementTipTrigger;
    [Header("Dash")]
    public GameObject dashTipMenu;
    public GameObject dashTipTrigger;
    [Header("Ranged Enemy")]
    public GameObject rangedTipMenu;
    public GameObject rangedTipTrigger;
    [Header("Wall Movement")]
    public GameObject wallTipMenu;
    public GameObject wallTipTrigger;
    [Header("Light Enemy")]
    public GameObject lightTipMenu;
    public GameObject lightTipTrigger;
    [Header("Heavy Enemy")]
    public GameObject heavyTipMenu;
    public GameObject heavyTipTrigger;

    void Update()
    {
        // Movement
        try
        {
            movementTipTrigger = GameObject.FindGameObjectWithTag("Movement"); // this is goint to find a certain tagged object from hirarchey and assing it to target.
            
        }
        catch (NullReferenceException)
        {
            Debug.Log("target gameObject is not present in hierarchy ");
        }
        // Dash
        try
        {
            dashTipTrigger = GameObject.FindGameObjectWithTag("Dash"); // this is goint to find a certain tagged object from hirarchey and assing it to target.
        }
        catch (NullReferenceException)
        {
            Debug.Log("target gameObject is not present in hierarchy ");
        }
        // Ranged
        try
        {
            rangedTipTrigger = GameObject.FindGameObjectWithTag("Ranged"); // this is goint to find a certain tagged object from hirarchey and assing it to target.
        }
        catch (NullReferenceException)
        {
            Debug.Log("target gameObject is not present in hierarchy ");
        }
        // Wall Movement
        try
        {
            wallTipTrigger = GameObject.FindGameObjectWithTag("Wall Movement"); // this is goint to find a certain tagged object from hirarchey and assing it to target.
        }
        catch (NullReferenceException)
        {
            Debug.Log("target gameObject is not present in hierarchy ");
        }
        // Light
        try
        {
            lightTipTrigger = GameObject.FindGameObjectWithTag("Light"); // this is goint to find a certain tagged object from hirarchey and assing it to target.
        }
        catch (NullReferenceException)
        {
            Debug.Log("target gameObject is not present in hierarchy ");
        }
        // Heavy
        try
        {
            heavyTipTrigger = GameObject.FindGameObjectWithTag("Heavy"); // this is goint to find a certain tagged object from hirarchey and assing it to target.
        }
        catch (NullReferenceException)
        {
            Debug.Log("target gameObject is not present in hierarchy ");
        }
    }

    void Start()
    {
        movementTipMenu.SetActive(false);
        dashTipMenu.SetActive(false);
        rangedTipMenu.SetActive(false);
        wallTipMenu.SetActive(false);
        lightTipMenu.SetActive(false);
        heavyTipMenu.SetActive(false);
    }

    // Movement
    public void MovementEnter()
    {
        movementTipMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void MovementResume()
    {
        movementTipMenu.SetActive(false);
        Time.timeScale = 1;
        Destroy(movementTipTrigger);
    }

    // Dash
    public void DashEnter()
    {
        dashTipMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void DashResume()
    {
        dashTipMenu.SetActive(false);
        Time.timeScale = 1;
        Destroy(dashTipTrigger);
    }

    // Ranged Enemy
    public void RangedEnter()
    {
        rangedTipMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void RangedResume()
    {
        rangedTipMenu.SetActive(false);
        Time.timeScale = 1;
        Destroy(rangedTipTrigger);
    }

    // Wall Movement
    public void WallEnter()
    {
        wallTipMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void WallResume()
    {
        wallTipMenu.SetActive(false);
        Time.timeScale = 1;
        Destroy(wallTipTrigger);
    }

    // Light Enemy
    public void LightEnter()
    {
        lightTipMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void LightResume()
    {
        lightTipMenu.SetActive(false);
        Time.timeScale = 1;
        Destroy(lightTipTrigger);
    }

    // Heavy Enemy
    public void HeavyEnter()
    {
        heavyTipMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void HeavyResume()
    {
        heavyTipMenu.SetActive(false);
        Time.timeScale = 1;
        Destroy(heavyTipTrigger);
    }
}
