using System;
using UnityEditor;
using UnityEngine;

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
            var parent = _transform.parent;
            var isLocal = parent != null;
            EditorGUILayout.BeginVertical("box");
            
            if(!isLocal)
            {
                _transform.position = EditorGUILayout.Vector3Field("Position", _transform.position);
                _transform.eulerAngles = EditorGUILayout.Vector3Field("Euler Angles", _transform.eulerAngles);
            }
            else
            {
                _transform.localPosition = EditorGUILayout.Vector3Field("Local Position", _transform.localPosition);
                _transform.localEulerAngles = EditorGUILayout.Vector3Field("Local Euler Angles", _transform.localEulerAngles);

                GlobalPropertiesUI();
            }

            _transform.localScale = EditorGUILayout.Vector3Field("Scale", _transform.localScale);
            
            EditorGUILayout.EndVertical();
        }

        private void GlobalPropertiesUI()
        {
            EditorGUILayout.Space(10);
            EditorGUILayout.BeginVertical("box");
            
            _transform.position = EditorGUILayout.Vector3Field("Global Position", _transform.position);
            _transform.eulerAngles = EditorGUILayout.Vector3Field("Global Euler Angles", _transform.eulerAngles);
            
            EditorGUILayout.EndVertical();
            
            EditorGUILayout.Space(10);
        }
    }
}