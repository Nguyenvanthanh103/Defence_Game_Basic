using UnityEngine;

namespace VanThanh.Defense_basic {
public static class Pref 
{
   public static int bestScore {
    set {
        int oldBestScore = PlayerPrefs.GetInt(Const.BEST_SCORE);
        if(oldBestScore < value){
            PlayerPrefs.SetInt(Const.BEST_SCORE,value);
        }
    }
    get => PlayerPrefs.GetInt(Const.BEST_SCORE,0);
   }

   public static int currentIdPlayer {
    set => PlayerPrefs.SetInt(Const.CURRENT_PLAYER_ID,value);
    get => PlayerPrefs.GetInt(Const.CURRENT_PLAYER_ID,0);
    }

    public static int coin {
      set => PlayerPrefs.SetInt(Const.COIN,value);
      get => PlayerPrefs.GetInt(Const.COIN,0);
    }
}
}

