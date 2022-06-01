using UnityEngine;

public class MovementTip_Trigger : MonoBehaviour
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
            menu.MovementEnter();
        }
    }
}
