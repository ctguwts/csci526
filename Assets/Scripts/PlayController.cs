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

    private float Timer;//攻击间隙计时器
    private float FixedTime=2;//攻击时间间隔
    public int currenthealth;
    public int maxhealth = 10;
    void Start()
    {
        Timer = -1;
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
        currenthealth = 5;
    }

    // Update is called once per frame
    void Update()
    {

        if(Timer>0)
        {
            Timer = Timer - Time.deltaTime;
        }
        else
        {
            anim.SetFloat("attack", 0.0f);
        }
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

        if (Input.GetKeyDown(KeyCode.J)&&Timer<0)
        {
            Debug.Log("玩家攻击了");
            anim.SetFloat("attack", 4.0f);
            Timer = FixedTime;
        }
    }
    public void changeHealth(int number)
    {
        currenthealth = Mathf.Clamp(currenthealth + number, 0, maxhealth);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController ec = other.gameObject.GetComponent<EnemyController>();
        if (ec != null&&Timer>0)
        {
            ec.EnermyDie();
        }
    }
}
