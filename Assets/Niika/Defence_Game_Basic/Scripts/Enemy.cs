using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb2d;

    public float enemySpeed = -2f;

    public float atkDistance;
    private Hero hero;
    public bool isAttacking = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        hero = FindFirstObjectByType<Hero>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hero.isDeath) return ;
        if(rb2d){
            rb2d.linearVelocity = new Vector2(enemySpeed,0);
        }
        if(Vector2.Distance(hero.transform.position,transform.position)<=atkDistance){
            if(anim){
                anim.SetBool(Const.ATTACK_ANIM,true);
                isAttacking = true;
            }
            rb2d.linearVelocity = Vector2.zero;
        }
    }
   
}
