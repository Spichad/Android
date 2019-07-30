using UnityEngine;
using System.Collections;

public class Instruction : MonoBehaviour {

public void instruct()
    {
        gameObject.active = !gameObject.active;
    }
}
