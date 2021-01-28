using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家打开宝箱脚本
/// </summary>
public class WoodChest : MonoBehaviour
{
    
    Animator anim;
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
        float val = 4.0f;
        PlayController pc = other.gameObject.GetComponent<PlayController>();
        if (pc != null)
        {
            anim.SetFloat("isopen", 4.0f);
          //  anim.SetFloat("isopen", 4.0f);
            Debug.Log("玩家采集了宝箱!");
        }
    }
}
