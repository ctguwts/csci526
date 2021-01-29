using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3;
    private Rigidbody2D rbody;

    public float DieCount = 3.0f;
    public int isDie = 0;

    public bool isVertical;//垂直方向移动
    public float nowtime;
    public float fixedtime=2;
    private Vector2 moveDirection;//移动方向
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        nowtime = fixedtime;
        rbody = GetComponent<Rigidbody2D>();
        moveDirection = isVertical ? Vector2.up : Vector2.right;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDie == 1)
        {
            DieCount = DieCount - Time.deltaTime;
            if (DieCount < 0)
                Destroy(this.gameObject);
        }
        nowtime = nowtime - Time.deltaTime;
        if (nowtime < 0)
        {
            nowtime = fixedtime;
            moveDirection = moveDirection * -1;
        }
        Vector2 position = rbody.position;
        position.x += moveDirection.x * speed * Time.deltaTime;
        position.y += moveDirection.y * speed * Time.deltaTime;
        rbody.MovePosition(position);
    }
    public void EnermyDie()
    {
        anim.SetFloat("die", 4.0f);
        isDie = 1;
        speed = 0;
    }
}
