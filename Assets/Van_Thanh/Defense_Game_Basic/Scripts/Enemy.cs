using System.Collections;
using UnityEngine;
 
namespace VanThanh.Defense_basic {
    class Enemy: MonoBehaviour,IComponentChecking {

        private Animator anim;
        private Rigidbody2D rb2d;

        private Player player;

        private float atkDistance = 1.5f;
        public float enemySpeed;

        private GameManager gameManager;

        public bool isDeath = false;

        private void Awake()
        {
            
            anim = GetComponent<Animator>();
            rb2d = GetComponent<Rigidbody2D>();
            player = FindFirstObjectByType<Player>();
            gameManager = FindFirstObjectByType<GameManager>();
        }
        public bool IsComponentNull(){
           return anim == null | rb2d == null | player == null;
        }
        private void Update()
        {
            if(IsComponentNull()) return;
            if(rb2d) {

                rb2d.linearVelocity = new Vector2 (-enemySpeed,rb2d.linearVelocity.y);
                
            }
            float distanceToPlayer = Vector2.Distance(player.transform.position,transform.position);
            Debug.Log(distanceToPlayer);
            if( distanceToPlayer<= atkDistance) {
                    anim.SetBool(Const.ATTACK_ANIM,true);
                    rb2d.linearVelocity = Vector2.zero;
                
            }
        }

        public void Die () {
            if(IsComponentNull()) return;
            anim.SetTrigger(Const.DEATH_ANIM);
            rb2d.linearVelocity = Vector2.zero;
            isDeath = true;
            if(gameManager) {
                gameManager.score++;
            }
            Destroy(gameObject,2f);
        }


    }

}
