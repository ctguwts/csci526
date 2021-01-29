using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家打开宝箱脚本
/// </summary>
public class WoodChest : MonoBehaviour
{
    
    Animator anim;
    int used = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        PlayController pc = other.gameObject.GetComponent<PlayController>();
        if (pc != null)
        {
            anim.SetFloat("isopen", 4.0f);
      
            if ((pc.currenthealth < pc.maxhealth)&&used==0)
            {
                pc.changeHealth(1);
               // Destroy(this.gameObject);
                Debug.Log("玩家采集了宝箱，生命值增加至"+pc.currenthealth);
                Debug.Log("玩家采集了宝箱!");
                used = 1;
            }
            
        }
    }
}
