using UnityEngine;
 
namespace VanThanh.Defense_basic {
    class Enemy: MonoBehaviour,IComponentChecking {

        private Animator anim;
        private Rigidbody2D rb2d;

        private Player player;

        private float atkDistance = 1.4f;
        public float enemySpeed;

        private bool isDeath = false;

        private void Awake()
        {
            
            anim = GetComponent<Animator>();
            rb2d = GetComponent<Rigidbody2D>();
            player = FindFirstObjectByType<Player>();
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
            if(Vector2.Distance(player.transform.position,transform.position) <= atkDistance) {
                    anim.SetBool(Const.ATTACK_ANIM,true);
                    rb2d.linearVelocity = Vector2.zero;
                
            }
        }

    }

}
