using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class LevelSystemComponent : MonoBehaviour {
    public RequiredXPGrowthType requiredXPGrowthType;
    public float requiredXP;
    public float requiredXPGrowth; // add, add percent to "requiredXP" or multiply "requiredXP" based on "RequiredXPGrowthType"

    [HideInInspector] public int currentXP = 0;
    public int level = 1;
    public UnityEvent onLevelUp; // Functions that will call when level up;

    void Start() {
        
    }
    void Update() {
        
    }
    /// <summary>   
    /// Increase level by 1 and do other needed stuff
    /// </summary>
    public void LevelUp() {
        level++;
        if(requiredXPGrowthType == RequiredXPGrowthType.ArithmeticProgression) {
            requiredXP += requiredXPGrowth;
        } else if (requiredXPGrowthType == RequiredXPGrowthType.GeometricProgression) {
            requiredXP *= requiredXPGrowth;
        } else if (requiredXPGrowthType == RequiredXPGrowthType.PercentageProgression) {
            requiredXP *= requiredXPGrowth;
            requiredXP /= 100;
        }
        
        onLevelUp?.Invoke(); // Needed functions call
        
    }
    /// <summary>   
    /// Add experience
    /// </summary>

    public void GainXP(int amount) {
        currentXP += amount;
        if (currentXP >= requiredXP) {
            currentXP = currentXP - (int)requiredXP;
            LevelUp();
        }
    }
    public void Print1(string s) {
        Debug.Log("Level up! " + s);
    }
    public void Print2() {
        Debug.Log(level);
    }
}


public enum RequiredXPGrowthType {
    ArithmeticProgression, // will add "requiredXPGrowth" to "requiredXP"
    GeometricProgression, // will multiply "requiredXP" by "requiredXPGrowth"
    PercentageProgression // will add "requiredXPGrowth" percent to "requiredXP"
}

/// <summary>   
/// Class for custom inspector
/// </summary>
    #region Editor
#if UNITY_EDITOR
[CustomEditor(typeof(LevelSystemComponent))]
public class LevelSystemEditor : Editor {
    #region SerializedProperties
    SerializedProperty requiredXPGrowthType;
    SerializedProperty onLevelUp;
    #endregion
    
    private void OnEnable() {
        requiredXPGrowthType = serializedObject.FindProperty("requiredXPGrowthType");
        onLevelUp = serializedObject.FindProperty("onLevelUp");
    }
    
    public override void OnInspectorGUI() {
        var levelSystem = (LevelSystemComponent)target;
        int MaxWidth = 175; // Max label width

        serializedObject.Update();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Required XP Growth Type", GUILayout.Width(MaxWidth));
        EditorGUILayout.PropertyField(requiredXPGrowthType, GUIContent.none, true, GUILayout.MaxWidth(MaxWidth));
        GUILayout.EndHorizontal();
        serializedObject.ApplyModifiedProperties();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Required XP", GUILayout.MaxWidth(MaxWidth));
        levelSystem.requiredXP = EditorGUILayout.FloatField(levelSystem.requiredXP);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Required XP Growth", GUILayout.MaxWidth(MaxWidth));
        levelSystem.requiredXPGrowth = EditorGUILayout.FloatField(levelSystem.requiredXPGrowth);
        EditorGUILayout.EndHorizontal();

        if(levelSystem.requiredXPGrowth < 0f) {
            levelSystem.requiredXPGrowth = 0f;
        }
        if(levelSystem.requiredXPGrowthType == RequiredXPGrowthType.ArithmeticProgression) {
            levelSystem.requiredXPGrowth = Mathf.RoundToInt(levelSystem.requiredXPGrowth);
        }

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Level", GUILayout.MaxWidth(MaxWidth));
        levelSystem.level = EditorGUILayout.IntField(levelSystem.level);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.PropertyField(onLevelUp);
    }
}
#endif
    #endregion
