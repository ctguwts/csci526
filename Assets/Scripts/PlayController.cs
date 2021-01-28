using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    private Animator anim;
    private Transform trans;
    private Vector2 lookDirection = new Vector2(1, 0);//玩家默认朝向右方
    void Start()
    {
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveVector = new Vector2(moveX, moveY);
        if(moveVector.x!=0)
        {
            if (moveVector.x > 0)
                trans.rotation = Quaternion.Euler(0.0f, 180f, 0.0f);
            if (moveVector.x < 0)
                trans.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

        }
      /*  if (moveVector.x != 0 || moveVector.y != 0)
        {
            lookDirection = moveVector;
        }
      */
        anim.SetFloat("sudu", moveVector.magnitude);
        Vector2 position = transform.position;
        position.x += moveX * speed * Time.deltaTime;
        position.y += moveY * speed * Time.deltaTime;
        transform.position = position;
    }
}
