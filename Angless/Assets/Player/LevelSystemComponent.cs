using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelSystemComponent : MonoBehaviour {
    public int level = 1;
    public UnityEvent onLevelUp; // Functions that will call when level up;
    /// <summary>   
    /// Increase level by 1 and do other needed stuff
    /// </summary>
    public void LevelUp() {
        level++;
        onLevelUp?.Invoke(); // Needed functions call
    }
    public void Print1(string s) {
        Debug.Log("Level up! " + s);
    }
    public void Print2() {
        Debug.Log(level);
    }
}