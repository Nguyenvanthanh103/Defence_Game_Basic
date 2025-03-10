using UnityEngine;

namespace VanThanh.Defense_basic {
    class Player : MonoBehaviour,IComponentChecking {

    private Animator anim;
    public float atkRate;
    private float curAtkRate;
    private bool isAttacked = false;

    private bool isDeath = false;

    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        curAtkRate = atkRate;
    }
    public bool IsComponentNull(){
        return anim == null;
    }
    private void Update()
    {
        if(IsComponentNull()) return;
        if(Input.GetMouseButtonDown(0)){
            if(anim) {
                anim.SetBool(Const.ATTACK_ANIM,true);
            }
            
        }
        if(isAttacked) {
                curAtkRate -= Time.deltaTime;
                if(curAtkRate <=0){
                    isAttacked = false;
                    curAtkRate = atkRate;
                }
            }
    }

    private void ResetAttack () {
        if(anim){
            anim.SetBool(Const.ATTACK_ANIM,false);
        }
        isAttacked = true;
    }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsComponentNull()) return;

            if(collision.CompareTag(Const.ENEMY_WEAPON_TAG) && !isDeath){
                anim.SetTrigger(Const.DEATH_ANIM);
                isDeath = true;
            }
        }
    }
}
