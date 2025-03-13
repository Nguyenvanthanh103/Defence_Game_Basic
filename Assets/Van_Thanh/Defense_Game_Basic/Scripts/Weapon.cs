using UnityEngine;

namespace VanThanh.Defense_basic {

  class Weapon : MonoBehaviour {


    private void Awake() {
       
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(Const.ENEMY_TAG)){
            Enemy enemy = other.GetComponent<Enemy>();
            if(enemy && !enemy.isDeath){
                enemy.Die();
            }
        }
    }
  }
}