using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Helpers
{
    [CustomEditor(typeof(Transform))]
    public class TransformEditor : Editor
    {
        private Transform _transform;

        private void OnEnable()
        {
            _transform = target as Transform;
        }


        public override void OnInspectorGUI()
        {
            BaseUI();
        }

        private void BaseUI()
        {
            EditorGUI.BeginChangeCheck();
            
            var parent = _transform.parent;
            var isLocal = parent != null;
            EditorGUILayout.BeginVertical("box");
            
            if(!isLocal)
            {
                GlobalPropertiesUI();
            }
            else
            {
                LocalPropertiesUI();
            }

            ScaleUI();
            

            EditorGUILayout.EndVertical();

            if (EditorGUI.EndChangeCheck())
            {
                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            }
        }

        private void GlobalPropertiesUI()
        {
            EditorGUILayout.Space(10);
            EditorGUILayout.BeginVertical("box");
         
            EditorGUI.BeginChangeCheck();
            
            var globalPos = EditorGUILayout.Vector3Field("Global Position", _transform.position);
            var globalEuler = EditorGUILayout.Vector3Field("Global Euler Angles", _transform.eulerAngles);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Global Properties");
                _transform.position = globalPos;
                _transform.eulerAngles = globalEuler;
            }
            
            EditorGUILayout.EndVertical();
            
            EditorGUILayout.Space(10);
        }
        
        private void LocalPropertiesUI()
        {
            EditorGUI.BeginChangeCheck();
            var localPos = EditorGUILayout.Vector3Field("Local Position", _transform.localPosition);
            var localEuler = EditorGUILayout.Vector3Field("Local Euler Angles", _transform.localEulerAngles);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Local Properties");

                _transform.localPosition = localPos;
                _transform.localEulerAngles = localEuler;
            }
                
            GlobalPropertiesUI();
        }

        private void ScaleUI()
        {
            EditorGUI.BeginChangeCheck();
            var localScale = EditorGUILayout.Vector3Field("Scale", _transform.localScale);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Local Scale");

                _transform.localScale = localScale;
            }
        }
    }
}