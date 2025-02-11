using UnityEngine;

public class Hero : MonoBehaviour
{
    private Animator anim;
    public float attackRate;
    private float curAttackRate;

    private bool isAttacked = false ;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        
        curAttackRate = attackRate;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space)){
             HeroAttack();
       }
    }
    private void HeroAttack(){
         
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
}
