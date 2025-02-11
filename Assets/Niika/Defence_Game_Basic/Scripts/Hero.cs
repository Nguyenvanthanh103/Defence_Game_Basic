using UnityEngine;

public class Hero : MonoBehaviour
{
    private Animator anim;
    private Enemy enemy;
  
    public float attackRate;
    private float curAttackRate;

    private bool isAttacked = false ;
    public bool isDeath = false;
    void Awake()
    {
        anim = GetComponent<Animator>();
        enemy = FindFirstObjectByType<Enemy>();
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        
        curAttackRate = attackRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject == null) return;
        Debug.Log(gameObject);
       if(Input.GetKeyDown(KeyCode.Space)){
             HeroAttack();
       }
    }
    private void HeroAttack(){
         if(gameObject == null) return;
            if(anim) {
                anim.SetBool(Const.ATTACK_ANIM,true);
                isAttacked = true;
            }
       
        if(isAttacked) {
            curAttackRate-=Time.deltaTime;
            if(curAttackRate<=0){
                isAttacked = false;
                
                curAttackRate = attackRate;
            }
        }
    }
    private void ResetAttack(){

        if(anim){
            anim.SetBool(Const.ATTACK_ANIM,false);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if(gameObject == null) return;
        if(collision.CompareTag("EnemyWeapon") && enemy.isAttacking){    
           if(!isDeath){
            Death();
           }
        }
       Invoke("DestroyHero",2f);
        
    }
    private void Death(){
        if(anim){
            anim.SetTrigger(Const.DEAD_ANIM);
        }
        isDeath = true;
        
    }
    private void DestroyHero(){
       Destroy(gameObject);
    }
}
