using Unity.VisualScripting;
using UnityEngine;

public class Hero : MonoBehaviour
{
    float score;
    void Start()
    {
        var scorePalyer = PlayerPrefs.GetFloat("score",0);
        Debug.Log(scorePalyer);
    }
    void Update(){
        score +=10;
        PlayerPrefs.SetFloat("score",score);
    }
    
}
