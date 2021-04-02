using UnityEngine;
using UnityEditor;

// [CustomEditor(typeof(RealLifeController))]
// public class RealLifeControllerEditor : Editor 
// {
//     SerializedProperty rightResponder;
//     SerializedProperty leftResponder;
//     SerializedProperty spaceResponder;
    
//     void OnEnable()
//     {
//         rightResponder = serializedObject.FindProperty("rightResponder");
//         leftResponder = serializedObject.FindProperty("leftResponder");
//         spaceResponder = serializedObject.FindProperty("spaceResponder");
//     }

//     public override void OnInspectorGUI()
//     {
//         serializedObject.Update();

//         rightResponder.objectReferenceValue = EditorGUILayout.ObjectField(
//             "Right Responder",
//             rightResponder.objectReferenceValue,
//             typeof(IInputResponder),
//             true // allow scene objects
//         );
//         serializedObject.ApplyModifiedProperties();
//     }
// }