using System.Collections;
using TMPro;
using UnityEngine;

namespace VanThanh.Defense_basic {

    class GameManager : MonoBehaviour {

        public float spawnTime;
        public Enemy[] enemies;

        private Player player;

        public TextMeshProUGUI textMeshPro;

        public float score = 0;

        private bool isGameOver = false;

        private void Awake() {
            player = FindFirstObjectByType<Player>();
            textMeshPro.text = score.ToString();
        }
        private void Start() {
            
            StartCoroutine(SpawnEnemy());
        }
        private void Update() {
            if(player.isDeath) isGameOver = true;
            textMeshPro.text = score.ToString();
        }
        IEnumerator SpawnEnemy(){
            
           while (!isGameOver)
           {
            if(enemies != null & enemies.Length > 0){
                int indexEnemy = Random.Range(0,enemies.Length);
                Enemy enemyPrefab = enemies[indexEnemy];
                Instantiate(enemyPrefab,new Vector3(5,0,0),Quaternion.identity);
            }
            yield return new WaitForSeconds(spawnTime);
           };
           

        }
    }
}