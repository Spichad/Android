using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelSel : MonoBehaviour {
    public Button[] levels;
    public int passed;
public void selectlvl (int n)
    {
        SceneManager.LoadScene("lvl"+n.ToString());
    }
public void Start()
    {

       passed= PlayerPrefs.GetInt("passed");
        for (int i = 1; i <= passed; i++) levels[i].interactable = true;
        Debug.Log("Levels passed: "+passed.ToString());
    }
public void DeleteSave()
    {
        Debug.Log("Deleted");
        PlayerPrefs.SetInt("passed", 0);
        SceneManager.LoadScene("Menu");
    }
}
