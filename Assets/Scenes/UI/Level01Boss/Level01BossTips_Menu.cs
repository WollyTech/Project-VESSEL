using System;
using UnityEngine;

public class Level01BossTips_Menu : MonoBehaviour
{
    [Header("Levitator")]
    public GameObject levitatorTipMenu;
    public GameObject levitatorTipTrigger;

    void Start()
    {
        levitatorTipMenu.SetActive(false);
    }

    void Update()
    {
        try
        {
            levitatorTipTrigger = GameObject.FindGameObjectWithTag("Levitator"); // this is goint to find a certain tagged object from hirarchey and assing it to target.
        }
        catch (NullReferenceException)
        {
            Debug.Log("target gameObject is not present in hierarchy ");
        }
    }

    public void LevitatorEnter()
    {
        levitatorTipMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevitatorResume()
    {
        levitatorTipMenu.SetActive(false);
        Time.timeScale = 1;
        Destroy(levitatorTipTrigger);
    }
}
