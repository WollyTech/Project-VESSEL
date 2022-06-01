using UnityEngine;

public class PureVesselTip_Trigger : MonoBehaviour
{
    public FinalBossTips_Menu menu;

    // Find the Scrpit
    public void Update()
    {
        menu = GameObject.Find("FinalBossOverlay").GetComponent<FinalBossTips_Menu>();
    }

    // What happens when collided with
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            menu.PureVesselEnter();
        }
    }
}
