using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelProp : MonoBehaviour {
    public int maxstars;
    public string nextlevel="";
    public int lvln;
    public bool allowed=true;
    public bool scch=false;
    public int levelpassed=0;        
    void Start()
    {
        if (nextlevel == "") { nextlevel = "lvl" + (lvln+1).ToString(); }
        levelpassed = PlayerPrefs.GetInt("passed");
    }
    public void NextS()
    {
        if (allowed && scch)
        {
            if (lvln > levelpassed) { levelpassed = lvln; PlayerPrefs.SetInt("passed", levelpassed); }
            SceneManager.LoadScene(nextlevel);
        }
    }
    public void RetryL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BtnExit()
    {
        Debug.Log("Exit");
        SceneManager.LoadScene(0);
    }
}
