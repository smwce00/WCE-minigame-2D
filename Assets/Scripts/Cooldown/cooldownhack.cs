using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cooldownhack : MonoBehaviour
{
    public Text timerText;              //Demo UI elements

    public int cooldown;                        //How often this cooldown may be used
    public float cooldownTimer;                 //Time left on timer, can be used at 0

    public Image skillImage1;

    public float cooldown1;
    public bool isCooldown = false;
    public KeyCode skillKey;

    // Start is called before the first frame update
    void Start()
    {
        cooldown1 = 2f;
        isCooldown = false;
        skillImage1.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Skill1();
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            int cooldownTimerInt = (int)cooldownTimer;
            timerText.text = cooldownTimerInt.ToString();
        }

        if (cooldownTimer < 0)
        {
            cooldownTimer = 0;
        }

        if (cooldownTimer == 0)
        {
            timerText.text = " ";
        }
    }

    void Skill1()
    {
        if (Input.GetKey(skillKey) && isCooldown == false)
        {
            cooldownTimer = cooldown1;
            skillImage1.fillAmount = 1;
            //isCooldown = true;
        }

        // 깎이는 애니메이션
        if (isCooldown == true)
        {
            skillImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if (skillImage1.fillAmount <= 0)
            {
                skillImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
}
