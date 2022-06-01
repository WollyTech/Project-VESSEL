using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attacking : MonoBehaviour
{
    [Header("Light")]
    public Image lightImage;
    public float cooldown1;
    bool isCooldown = false;
    public KeyCode lightAtt;

    [Header("Heavy")]
    public Image heavyImage;
    public float cooldown2;
    bool isCooldown2 = false;
    public KeyCode heavyAtt;

    [Header("Ranged")]
    public Image rangedImage;
    public float cooldown3;
    bool isCooldown3 = false;
    public KeyCode rangedAtt;

    // Start is called before the first frame update
    void Start()
    {
        lightImage.fillAmount = 0;
        heavyImage.fillAmount = 0;
        rangedImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Light();
        Heavy();
        Ranged();
    }

    void Light()
    {
        if (Input.GetKey(lightAtt) && isCooldown == false)
        {
            isCooldown = true;
            lightImage.fillAmount = 1;
        }
        if (isCooldown)
        {
            lightImage.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            if (lightImage.fillAmount <= 0)
            {
                lightImage.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

    void Heavy()
    {
        if (Input.GetKey(heavyAtt) && isCooldown2 == false)
        {
            isCooldown2 = true;
            heavyImage.fillAmount = 1;
        }
        if (isCooldown2)
        {
            heavyImage.fillAmount -= 1 / cooldown2 * Time.deltaTime;
            if (heavyImage.fillAmount <= 0)
            {
                heavyImage.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }

    void Ranged()
    {
        if (Input.GetKey(rangedAtt) && isCooldown3 == false)
        {
            isCooldown3 = true;
            rangedImage.fillAmount = 1;
        }
        if (isCooldown3)
        {
            rangedImage.fillAmount -= 1 / cooldown3 * Time.deltaTime;
            if (rangedImage.fillAmount <= 0)
            {
                rangedImage.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }


}
