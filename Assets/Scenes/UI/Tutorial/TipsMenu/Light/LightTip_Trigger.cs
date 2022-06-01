using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTip_Trigger : MonoBehaviour
{
    public TutorialTips_Menu menu;

    // Find the Scrpit
    public void Update()
    {
        menu = GameObject.Find("TutorialOverlay").GetComponent<TutorialTips_Menu>();
    }

    // What happens when collided with
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            menu.LightEnter();
        }
    }

}
