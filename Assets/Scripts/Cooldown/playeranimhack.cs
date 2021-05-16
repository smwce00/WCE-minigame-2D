using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeranimhack : MonoBehaviour
{
    Animator animator;

    private KeyCode skillKey;
    private bool isCooldown;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        skillKey = GameObject.Find("skill_icon_black").GetComponent<SkillCooldown_Cool2D>().skillKey;
    }

    // Update is called once per frame
    void Update()
    {
        isCooldown = GameObject.Find("skill_icon_black").GetComponent<SkillCooldown_Cool2D>().isCooldown;
        if (Input.GetKey(skillKey) && isCooldown == false)
        {
            Debug.Log("FW_attack1");
            animator.Play("FW_attack1");
            GameObject.Find("skill_icon_black").GetComponent<SkillCooldown_Cool2D>().isCooldown = true;
        }

        else if (Input.GetKey(skillKey) && isCooldown == true)
        {
            Debug.Log("Skill on cooldown");
        }

    }
}