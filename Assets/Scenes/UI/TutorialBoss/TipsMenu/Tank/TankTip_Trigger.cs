using UnityEngine;

public class TankTip_Trigger : MonoBehaviour
{
    public TutorialBossTips_Menu menu;

    // Find the Scrpit
    public void Update()
    {
        menu = GameObject.Find("Tut.BossOverlay").GetComponent<TutorialBossTips_Menu>();
    }

    // What happens when collided with
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            menu.TankEnter();
        }
    }
}
