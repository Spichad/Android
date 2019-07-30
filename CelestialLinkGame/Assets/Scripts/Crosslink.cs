using UnityEngine;
using System.Collections;

public class Crosslink : MonoBehaviour
{
    public LevelProp lvlp;
    public GameObject starSt=null, starFn=null;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Link")
        {
            if (!((starSt == other.gameObject.GetComponent<Crosslink>().starFn)||(starFn== other.gameObject.GetComponent<Crosslink>().starSt)))
            {
                lvlp.allowed = false;
                Debug.Log("Fail");
                lvlp.RetryL();
            }
        }

    }
}