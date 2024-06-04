using UnityEditor;
using UnityEngine;
using Microlight.MicroEditor;

namespace Microlight.MicroBar {
    // ****************************************************************************************************
    // For MicroBar menu in editor or right clicking in hierarchy
    // ****************************************************************************************************
    internal class MicroBar_EditorMenu : Editor {

        static string GetPrefabsFolder() {
            return MicroEditor_AssetUtility.FindFolderRecursively("Assets", "MicroBar") + "/Prefabs";
        }
        static void InstantiateBar(GameObject bar) {
            bar = Instantiate(bar);   // Instantiate
            bar.name = "HealthBar";   // Change name
            if(Selection.activeGameObject != null) {   // Make child if some object is selected
                bar.transform.SetParent(Selection.activeGameObject.transform, false);
            }
        }

        #region Bars
        [MenuItem("GameObject/Microlight/MicroBar/Blank", false, 100)]
        private static void AddBlankBar() {
            // Get prefab
            GameObject go = MicroEditor_AssetUtility.GetPrefab(GetPrefabsFolder(), "Blank_MicroBar");
            if(go == null) return;
            InstantiateBar(go);
        }
        [MenuItem("GameObject/Microlight/MicroBar/Basic")]
        private static void AddBasicBar() {
            // Get prefab
            GameObject go = MicroEditor_AssetUtility.GetPrefab(GetPrefabsFolder(), "Basic_MicroBar");
            if(go == null) return;
            InstantiateBar(go);
        }
        [MenuItem("GameObject/Microlight/MicroBar/Delayed")]
        private static void AddDelayedBar() {
            // Get prefab
            GameObject go = MicroEditor_AssetUtility.GetPrefab(GetPrefabsFolder(), "Delayed_MicroBar");
            if(go == null) return;
            InstantiateBar(go);
        }
        [MenuItem("GameObject/Microlight/MicroBar/Disappear")]
        private static void AddDisappearBar() {
            // Get prefab
            GameObject go = MicroEditor_AssetUtility.GetPrefab(GetPrefabsFolder(), "Disappear_MicroBar");
            if(go == null) return;
            InstantiateBar(go);
        }
        [MenuItem("GameObject/Microlight/MicroBar/Impact")]
        private static void AddImpactBar() {
            // Get prefab
            GameObject go = MicroEditor_AssetUtility.GetPrefab(GetPrefabsFolder(), "Impact_MicroBar");
            if(go == null) return;
            InstantiateBar(go);
        }
        [MenuItem("GameObject/Microlight/MicroBar/Punch")]
        private static void AddPunchBar() {
            // Get prefab
            GameObject go = MicroEditor_AssetUtility.GetPrefab(GetPrefabsFolder(), "Punch_MicroBar");
            if(go == null) return;
            InstantiateBar(go);
        }
        [MenuItem("GameObject/Microlight/MicroBar/Shake")]
        private static void AddShakeBar() {
            // Get prefab
            GameObject go = MicroEditor_AssetUtility.GetPrefab(GetPrefabsFolder(), "Shake_MicroBar");
            if(go == null) return;
            InstantiateBar(go);
        }
        //[MenuItem("GameObject/Microlight/UI Image Health Bar", true)]
        //private static bool AddImageHealthBar_Validate() {
        //    return Selection.activeGameObject && Selection.activeGameObject.GetComponentInParent<Canvas>();
        //}
        #endregion
    }
}