using UnityEditor;
using UnityEngine;

namespace Helpers
{
    public static class ContextMenuItems
    {
        private static Vector3 _copiedLocalPos;
        private static Vector3 _copiedGlobalPos;

        private static Vector3 _copiedLocalEuler;
        private static Vector3 _copiedGlobalEuler;
        
        #region LocalPos

        [MenuItem("CONTEXT/Transform/Copy Local Position")]
        private static void CopyLocalPosition()
        {
            _copiedLocalPos = Selection.activeTransform.localPosition;
        }

        [MenuItem("CONTEXT/Transform/Paste Local Position")]
        private static void PasteLocalPosition()
        {
            var obj = Selection.activeTransform;
            if(obj == null)
                return;
            
            Undo.RecordObject(obj, "Paste Local Pos");
            Selection.activeTransform.localPosition = _copiedLocalPos;
        }

        #endregion

        #region GLobalPos

        [MenuItem("CONTEXT/Transform/Copy Local Position")]
        private static void CopyGlobalPosition()
        {
            _copiedGlobalPos = Selection.activeTransform.position;
        }

        [MenuItem("CONTEXT/Transform/Paste Global Position")]
        private static void PasteGlobalPosition()
        {
            var obj = Selection.activeTransform;
            if(obj == null)
                return;
            
            Undo.RecordObject(obj, "Paste Global Pos");
            Selection.activeTransform.position = _copiedGlobalPos;
        }

        #endregion

        #region LocalEuler

        [MenuItem("CONTEXT/Transform/Copy Local Euler")]
        private static void CopyLocalEuler()
        {
            _copiedLocalEuler = Selection.activeTransform.localEulerAngles;
        }

        [MenuItem("CONTEXT/Transform/Paste Local Euler")]
        private static void PasteLocalEuler()
        {
            var obj = Selection.activeTransform;
            if(obj == null)
                return;
            
            Undo.RecordObject(obj, "Paste Local Pos");
            Selection.activeTransform.localEulerAngles = _copiedLocalEuler;
        }

        #endregion

        #region GlobalEuler

        [MenuItem("CONTEXT/Transform/Copy Global Euler")]
        private static void CopyGlobalEuler()
        {
            _copiedGlobalEuler = Selection.activeTransform.eulerAngles;
        }

        [MenuItem("CONTEXT/Transform/Paste Global Euler")]
        private static void PasteGlobalEuler()
        {
            var obj = Selection.activeTransform;
            if(obj == null)
                return;
            
            Undo.RecordObject(obj, "Paste Global Pos");
            Selection.activeTransform.eulerAngles = _copiedGlobalEuler;
        }

        #endregion
    }
}