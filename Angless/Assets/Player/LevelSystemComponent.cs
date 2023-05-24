using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelSystemComponent : MonoBehaviour {
    public int requiredXP;
    public int requiredXPGrowth;
    [HideInInspector]
    public int currentXP = 0;
    public int level = 1;
    public UnityEvent onLevelUp; // Function that call when level up;

    void Start() {
        
    }
    void Update() {
        
    }
    /// <summary>   
    /// Add experience
    /// </summary>
    public void LevelUp() {
        level++;
        requiredXP += requiredXPGrowth;
        onLevelUp?.Invoke(); // Function call
        
    }
    /// <summary>   
    /// Add experience
    /// </summary>

    public void GainXP(int amount) {
        currentXP += amount;
        if (currentXP >= requiredXP) {
            currentXP = currentXP - requiredXP;
            LevelUp();
        }
    }
    public void Print() {
        Debug.Log("Level up!");
        Debug.Log(level);
    }
}
