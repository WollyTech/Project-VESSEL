using UnityEngine;
using System;
public class TutorialBossTips_Menu : MonoBehaviour
{
    [Header("Tank")]
    public GameObject tankTipMenu;
    public GameObject tankTipTrigger;

    void Start()
    {
        tankTipMenu.SetActive(false);
    }

    void Update()
    {
        try
        {
            tankTipTrigger = GameObject.FindGameObjectWithTag("Tank"); // this is goint to find a certain tagged object from hirarchey and assing it to target.
        }
        catch (NullReferenceException)
        {
            Debug.Log("target gameObject is not present in hierarchy ");
        }
    }

    public void TankEnter()
    {
        tankTipMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void TankResume()
    {
        tankTipMenu.SetActive(false);
        Time.timeScale = 1;
        Destroy(tankTipTrigger);
    }
}
