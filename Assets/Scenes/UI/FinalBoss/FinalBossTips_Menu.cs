using UnityEngine;
using System;

public class FinalBossTips_Menu : MonoBehaviour
{
    [Header("Pure Vessel")]
    public GameObject pureVesselTipMenu;
    public GameObject pureVesselTipTrigger;

    void Start()
    {
        pureVesselTipMenu.SetActive(false);
    }

    void Update()
    {
        try
        {
            pureVesselTipTrigger = GameObject.FindGameObjectWithTag("Pure Vessel"); // this is goint to find a certain tagged object from hirarchey and assing it to target.
        }
        catch (NullReferenceException)
        {
            Debug.Log("target gameObject is not present in hierarchy ");
        }
    }

    public void PureVesselEnter()
    {
        pureVesselTipMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void PureVesselResume()
    {
        pureVesselTipMenu.SetActive(false);
        Time.timeScale = 1;
        Destroy(pureVesselTipTrigger);
    }
}
