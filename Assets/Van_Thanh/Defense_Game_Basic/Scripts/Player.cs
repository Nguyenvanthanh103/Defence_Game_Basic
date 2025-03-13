using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VanThanh.Defense_basic {
    class Player : MonoBehaviour,IComponentChecking {

    private Animator anim;
    public float atkRate;
    private float curAtkRate;
    private bool isAttacked = false;

    public bool isDeath = false;

    
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
        if(Input.GetKeyDown(KeyCode.Space)){
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
                Destroy(gameObject,1.5f);
            }
        }
        public string ReversePrefix(string word, char ch) {
            string result = "";
            Stack<char> stack = new Stack<char>();
            for(int i=0;i<word.Length;i++){
                if (word[i] == ch) return result;
                if(word[i] != ch) {
                    stack.Push(word[i]);
                }
                result += stack.Pop();
            }
            return result;
    }
    }
}
