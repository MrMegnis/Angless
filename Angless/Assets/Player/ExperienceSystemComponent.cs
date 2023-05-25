using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class ExperienceSystemComponent : MonoBehaviour {
    public RequiredXPGrowthType requiredXPGrowthType;
    public float requiredXP;
    public float requiredXPGrowth; // add, add percent to "requiredXP" or multiply "requiredXP" based on "RequiredXPGrowthType"
    public UnityEvent onXPReset; // Functions that will call when level up;

    [HideInInspector] public int currentXP = 0;
    /// <summary>   
    /// Add experience
    /// </summary>
    public void GainXP(int amount) {
        currentXP += amount;
        if (currentXP >= requiredXP) {
            currentXP = currentXP - (int)requiredXP;
            XPReset();
        }
    }
    /// <summary>   
    /// Reset experience
    /// </summary>
    public void XPReset() {
        if(requiredXPGrowthType == RequiredXPGrowthType.ArithmeticProgression) {
            requiredXP += requiredXPGrowth;
        } else if (requiredXPGrowthType == RequiredXPGrowthType.GeometricProgression) {
            requiredXP *= requiredXPGrowth;
        } else if (requiredXPGrowthType == RequiredXPGrowthType.PercentageProgression) {
            requiredXP *= requiredXPGrowth;
            requiredXP /= 100;
        }
        onXPReset?.Invoke(); // Needed functions call
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
[CustomEditor(typeof(ExperienceSystemComponent))]
public class ExperienceSystemEditor : Editor {
    #region SerializedProperties
    SerializedProperty requiredXPGrowthType;
    SerializedProperty onXPReset;
    #endregion
    
    private void OnEnable() {
        requiredXPGrowthType = serializedObject.FindProperty("requiredXPGrowthType");
        onXPReset = serializedObject.FindProperty("onXPReset");
    }
    
    public override void OnInspectorGUI() {
        var experienceSystem = (ExperienceSystemComponent)target;

        int MaxWidth = 175; // Max label width

        serializedObject.Update();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Required XP Growth Type", GUILayout.Width(MaxWidth));
        EditorGUILayout.PropertyField(requiredXPGrowthType, GUIContent.none, true, GUILayout.MaxWidth(MaxWidth));
        GUILayout.EndHorizontal();
        serializedObject.ApplyModifiedProperties();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Required XP", GUILayout.MaxWidth(MaxWidth));
        experienceSystem.requiredXP = EditorGUILayout.FloatField(experienceSystem.requiredXP);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Required XP Growth", GUILayout.MaxWidth(MaxWidth));
        experienceSystem.requiredXPGrowth = EditorGUILayout.FloatField(experienceSystem.requiredXPGrowth);
        EditorGUILayout.EndHorizontal();

        if(experienceSystem.requiredXPGrowth < 0f) {
            experienceSystem.requiredXPGrowth = 0f;
        }
        if(experienceSystem.requiredXPGrowthType == RequiredXPGrowthType.ArithmeticProgression) {
            experienceSystem.requiredXPGrowth = Mathf.RoundToInt(experienceSystem.requiredXPGrowth);
        }
        serializedObject.Update();
        EditorGUILayout.PropertyField(onXPReset);
        serializedObject.ApplyModifiedProperties();
        
    }
}
#endif
    #endregion