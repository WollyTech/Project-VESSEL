using UnityEngine;

public class LevitatorTip_Trigger : MonoBehaviour
{
    public Level01BossTips_Menu menu;

    // Find the Scrpit
    public void Update()
    {
        menu = GameObject.Find("Level01BossOverlay").GetComponent<Level01BossTips_Menu>();
    }

    // What happens when collided with
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            menu.LevitatorEnter();
        }
    }
}
