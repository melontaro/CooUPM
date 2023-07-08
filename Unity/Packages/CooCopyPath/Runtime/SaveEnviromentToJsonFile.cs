#if ENABLE_CODES
using System.Collections.Generic;
using System.IO;
using System.Net;
using Coo;
using ET;
using Newtonsoft.Json;
//using Newtonsoft.Json.UnityConverters.Math;
//using Newtonsoft.Json.UnityConverters;
using UnityEditor;
using UnityEngine;
using ET.Client;

namespace CooCoo
{

    

    public static class SaveEnviromentToJsonFile
    {

        [MenuItem("GameObject/保存场景ToJsonFile", false, 0)]
        public static void Save()
        {
    
            List<MapPrefabInfo> PrefabInfos = new List<MapPrefabInfo>();

            Transform[] all = Selection.gameObjects[0].GetComponentsInChildren<Transform>(true);
            List<string> paths = new List<string>();
            foreach (var item in all)
            {
                var path = GetPath(item.gameObject);
                if (paths.Contains(path)) continue;
                paths.Add(path);
                if (path != string.Empty)
                {
                    PrefabInfos.Add(new MapPrefabInfo()
                    {
                        parentName = item.parent != null ? item.parent.name : string.Empty, name = item.gameObject.name,
                        path = path,
                        position = new Vct3(item.localPosition.x, item.localPosition.y, item.localPosition.z) , 
                        rotation = new Vct3(item.rotation.x, item.rotation.y, item.rotation.z),
                        scale = new Vct3(item.localScale.x, item.localScale.y, item.localScale.z)
                    }) ;
                }
            }
            /*
            var settings = new JsonSerializerSettings
            {
                Converters = new[] {
        new Vector3Converter(),

    },
                ContractResolver = new UnityTypeContractResolver(),
            };

            */

            string json = JsonConvert.SerializeObject(PrefabInfos, Formatting.Indented);
            Debug.LogError(json); 
            string filePath = Application.dataPath + "/Bundles/MapTextAsset" + "/{0}.json";
            string fullPath = string.Format(filePath, Selection.gameObjects[0].name);
            File.WriteAllText(fullPath, json);
        var info = JsonConvert.DeserializeObject<List<MapPrefabInfo>>(json);
            Debug.Log(info);


            AssetDatabase.Refresh();
        }


        public static string GetPath(GameObject targetGameObject)
        {
            string path = string.Empty;
            var prefab = UnityEditor.PrefabUtility.GetPrefabInstanceHandle(targetGameObject);
            if (prefab != null)
            {
                path = UnityEditor.PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(targetGameObject);
            }
            else
            {
                Debug.LogError("此物品没有预制：" + targetGameObject.name);
            }

            return path;
        }
    }

}
#endif