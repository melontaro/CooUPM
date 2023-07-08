using UnityEngine;
using System.Collections;
using UnityEditor;
using Cysharp.Text;
using System.Collections.Generic;
#if Lean
using Lean.Gui;
#endif
using TMPro;
using System.IO;
using UnityEngine.UI;
#if ETFramework
using ET;
#endif

public class CopyPathScript : MonoBehaviour
{
    [MenuItem("GameObject/CopyPath/CopyFullPath", false, 0)]
    static void InitFullPath()
    {
        if (Selection.gameObjects != null && Selection.gameObjects.Length == 1)
        {
            string pathStr = string.Empty;
            GetPath(Selection.gameObjects[0].transform, ref pathStr);

            TextEditor te = new TextEditor();
            te.text = pathStr;
            te.SelectAll();
            te.Copy();
        }
        else
        {
            Debug.LogError("请只选择一个物体进行复制路径;");
        }
    }

    // GetCompomentByPath<Text>("gongfaInfo/ScrollRect/Viewport/Content/gongfaAdd/txtShengMing/txtAttri");
    [MenuItem("GameObject/CopyPath/CopyTextByFullPath", false, 0)]
    static void InitFullByCommentTextPath()
    {
        if (Selection.gameObjects != null && Selection.gameObjects.Length == 1)
        {
            string pathStr = string.Empty;
            GetPath(Selection.gameObjects[0].transform, ref pathStr);

            TextEditor te = new TextEditor();
            pathStr = @"GetCompomentByPath<Text>(" + "\"" + pathStr + "\"" + ");";
            te.text = pathStr;
            te.SelectAll();
            te.Copy();
        }
        else
        {
            Debug.LogError("请只选择一个物体进行复制路径;");
        }
    }

    [MenuItem("GameObject/CopyPath/CopyImageByFullPath", false, 0)]
    static void InitFullByCommentImagePath()
    {
        if (Selection.gameObjects != null && Selection.gameObjects.Length == 1)
        {
            string pathStr = string.Empty;
            GetPath(Selection.gameObjects[0].transform, ref pathStr);

            TextEditor te = new TextEditor();
            pathStr = @"GetCompomentByPath<Image>(" + "\"" + pathStr + "\"" + ");";
            te.text = pathStr;
            te.SelectAll();
            te.Copy();
        }
        else
        {
            Debug.LogError("请只选择一个物体进行复制路径;");
        }
    }

    [MenuItem("GameObject/CopyPath/CopyParentPath", false, 0)]
    static void InitParent()
    {
        if (Selection.gameObjects != null && Selection.gameObjects.Length == 1)
        {
            TextEditor te = new TextEditor();
            if (Selection.gameObjects[0].transform.parent == null)
            {
                Debug.LogError("无父物体;");
            }
            else
            {
                string pathStr = string.Empty;
                GetPath(Selection.gameObjects[0].transform.parent, ref pathStr);
                te.text = pathStr;
                te.SelectAll();
                te.Copy();
            }
        }
        else
        {
            Debug.LogError("请只选择一个物体进行复制路径;");
        }
    }

    [MenuItem("GameObject/CopyPath/CopyName", false, 0)]
    static void InitName()
    {
        if (Selection.gameObjects != null && Selection.gameObjects.Length == 1)
        {
            string pathStr = Selection.gameObjects[0].name;
            TextEditor te = new TextEditor();
            te.text = pathStr;
            te.SelectAll();
            te.Copy();
        }
        else
        {
            Debug.ClearDeveloperConsole();
            Debug.LogError("请只选择一个物体进行复制路径;");
        }
    }

    static string GetPath(Transform tr, ref string str)
    {
        if (tr != null)
        {
            str = tr.name + str;
            tr = tr.parent;
            if (tr != null)
            {
                str = "/" + str;
            }

            GetPath(tr, ref str);
        }
        else
        {
            return str;
        }

        return str;
    }

    [MenuItem("GameObject/CreateBindPoint", false, 0)]
    static void CreateBindPoint()
    {
        if (Selection.gameObjects != null && Selection.gameObjects.Length == 1)
        {
            Transform parent = Selection.gameObjects[0].transform;
            GameObject bindObj = new GameObject();
            bindObj.transform.SetParent(parent, false);
            bindObj.name = "bindpoint";


            GameObject head = new GameObject();
            head.transform.SetParent(bindObj.transform, false);
            head.name = "head";

            GameObject body = new GameObject();
            body.transform.SetParent(bindObj.transform, false);
            body.name = "body";

            GameObject foot = new GameObject();
            foot.transform.SetParent(bindObj.transform, false);
            foot.name = "foot";
        }
        else
        {
            Debug.LogError("请只选择一个物体操作");
        }
    }

    [MenuItem("GameObject/生成UI代码", false, 0)]
    static void GenerateEGUI()
    {
        if (Selection.gameObjects != null && Selection.gameObjects.Length == 1)
        {
            Transform parent = Selection.gameObjects[0].transform;


            var sb = ZString.CreateStringBuilder();
            var sbObj = ZString.CreateStringBuilder();
            var sbFindObj = ZString.CreateStringBuilder();
            var sbBtn = ZString.CreateStringBuilder();
            var sbFindBtn = ZString.CreateStringBuilder();
            var sbText = ZString.CreateStringBuilder();
            var sbFindText = ZString.CreateStringBuilder();
            var sbInput = ZString.CreateStringBuilder();
            var sbFindInput = ZString.CreateStringBuilder();
            var sbOSA = ZString.CreateStringBuilder();
            var sbFindOSA = ZString.CreateStringBuilder();
            var sbSlider = ZString.CreateStringBuilder();
            var sbFindSlider = ZString.CreateStringBuilder();
            sb.Append("using UnityEngine;");
            sb.Append("using TMPro;");
            sb.Append("using UnityEngine.UI;");
            sb.Append("using Lean.Gui;");
            sb.Append("using ET;");
            Debug.LogError(parent.gameObject.name);
            sb.AppendFormat("public partial class {0}", parent.gameObject.name);
            sb.Append("{\r\n");

            GetAllEG(ref sbObj,ref sbFindObj);
            sb.Append(sbObj.ToString());


           var btns= GetAllButtons(ref sbBtn, ref sbFindBtn);
            sb.Append(sbBtn.ToString());

            GetAllTextMeshProUGUI(ref sbText,ref sbFindText);
            sb.Append(sbText.ToString());
            GetAllInputField(ref sbInput,ref sbFindInput);
            sb.Append(sbInput.ToString());
            GetAllEOSA(ref sbOSA,ref sbFindOSA);
            sb.Append(sbOSA.ToString());

            GetAllESlider(ref sbSlider,ref sbFindSlider);
            sb.Append(sbSlider.ToString());
            
            sb.AppendFormat("protected override void InitUIProperties(){0}", "{");
            sb.Append(sbFindObj.ToString());
            sb.Append(sbFindBtn.ToString());
            sb.Append(sbFindText.ToString());
            sb.Append(sbFindInput.ToString());
            sb.Append(sbFindOSA.ToString());
            sb.Append(sbFindSlider.ToString());

            sb.Append("}}");
            CreateFile(sb.ToString(),parent);
            CreateFormFile(btns,parent);
            Debug.Log(sb);
            ChangeLayer(parent,"UI");
            AssetDatabase.Refresh();
        }
        else
        {
            Debug.LogError("请只选择一个物体操作");
        }
    }
    static List<Transform> GetAllEG(ref Utf16ValueStringBuilder sb, ref Utf16ValueStringBuilder sbfind)
    {
        List<Transform> list = new List<Transform>();
        Transform[] all = Selection.gameObjects[0].GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < all.Length; i++)
        {
            if (all[i]!= null)
            {
                if (!all[i].name.StartsWith("EG_"))
                {
                    continue;
                }

                var childPath = GetPathRelativeToParent(all[i], Selection.gameObjects[0].transform);
                sb.AppendFormat("private GameObject {0};", all[i].name);
                sbfind.AppendFormat("{0}=", all[i].name);
                sbfind.AppendFormat(" this.transform.Find(\"{0}\").gameObject;", childPath);

                list.Add(all[i]);
            }
        }

        return list;
    }

    static List<Transform> GetAllButtons(ref Utf16ValueStringBuilder sb, ref Utf16ValueStringBuilder sbfind)
    {
        List<Transform> list = new List<Transform>();
        Transform[] all = Selection.gameObjects[0].GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < all.Length; i++)
        {
#if Lean
            if (all[i].GetComponent<LeanButton>() != null)
            {
                if (!all[i].name.StartsWith("E_"))
                {
                    continue;
                }

                var childPath = GetPathRelativeToParent(all[i], Selection.gameObjects[0].transform);
                sb.AppendFormat("private LeanButton {0};", all[i].name);
                sbfind.AppendFormat("{0}=", all[i].name);
                sbfind.AppendFormat(" this.transform.Find(\"{0}\").GetComponent<LeanButton>();", childPath);

                list.Add(all[i]);
            }
#endif
        }

        return list;
    }

    static List<Transform> GetAllTextMeshProUGUI(ref Utf16ValueStringBuilder sb, ref Utf16ValueStringBuilder sbfind)
    {
        List<Transform> list = new List<Transform>();
        Transform[] all = Selection.gameObjects[0].GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < all.Length; i++)
        {
#if Lean
            if (all[i].GetComponent<TextMeshProUGUI>() != null&& all[i].GetComponent<LeanButton>()==null)
            {
                if (!all[i].name.StartsWith("E_"))
                {
                    continue;
                }
                var childPath = GetPathRelativeToParent(all[i], Selection.gameObjects[0].transform);
                sb.AppendFormat("private TextMeshProUGUI {0};", all[i].name);
                sbfind.AppendFormat("{0}=", all[i].name);
                sbfind.AppendFormat(" this.transform.Find(\"{0}\").GetComponent<TextMeshProUGUI>();", childPath);
                list.Add(all[i]);
            }
#endif
        }

        return list;
    }

    static List<Transform> GetAllInputField(ref Utf16ValueStringBuilder sb, ref Utf16ValueStringBuilder sbfind)
    {
        List<Transform> list = new List<Transform>();
        Transform[] all = Selection.gameObjects[0].GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < all.Length; i++)
        {
            if (all[i].GetComponent<TMP_InputField>() != null)
            {
                if (!all[i].name.StartsWith("E_"))
                {
                    continue;
                }
                var childPath = GetPathRelativeToParent(all[i], Selection.gameObjects[0].transform);
                sb.AppendFormat("private TMP_InputField {0};", all[i].name);
                sbfind.AppendFormat("{0}=", all[i].name);
                sbfind.AppendFormat(" this.transform.Find(\"{0}\").GetComponent<TMP_InputField>();", childPath);
                list.Add(all[i]);
            }
        }

        return list;
    }
    static List<Transform> GetAllEOSA(ref Utf16ValueStringBuilder sb, ref Utf16ValueStringBuilder sbfind)
    {
        List<Transform> list = new List<Transform>();
        Transform[] all = Selection.gameObjects[0].GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < all.Length; i++)
        {
#if ETFramework
            if (all[i].GetComponent<MyBasicGridAdapter>() != null)
            {
                if (!all[i].name.StartsWith("EOSA_"))
                {
                    continue;
                }
                var childPath = GetPathRelativeToParent(all[i], Selection.gameObjects[0].transform);
                sb.AppendFormat("private MyBasicGridAdapter {0};", all[i].name);
                sbfind.AppendFormat("{0}=", all[i].name);
                sbfind.AppendFormat(" this.transform.Find(\"{0}\").GetComponent<MyBasicGridAdapter>();", childPath);
                list.Add(all[i]);
            }
#endif
        }

        return list;
    }
    
    
    static List<Transform> GetAllESlider(ref Utf16ValueStringBuilder sb, ref Utf16ValueStringBuilder sbfind)
    {
        List<Transform> list = new List<Transform>();
        Transform[] all = Selection.gameObjects[0].GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < all.Length; i++)
        {
            if (all[i].GetComponent<Slider>() != null)
            {
                if (!all[i].name.StartsWith("ESlider_"))
                {
                    continue;
                }
                var childPath = GetPathRelativeToParent(all[i], Selection.gameObjects[0].transform);
                sb.AppendFormat("private Slider {0};", all[i].name);
                sbfind.AppendFormat("{0}=", all[i].name);
                sbfind.AppendFormat(" this.transform.Find(\"{0}\").GetComponent<Slider>();", childPath);
                list.Add(all[i]);
            }
        }

        return list;
    }
    
    public static string GetPathRelativeToParent(Transform child, Transform parent)
    {
        string path = child.name;
        while (child.parent != null)
        {
            if (child.parent == parent)
            {
                break;
            }

            child = child.parent;
            path = child.name + "/" + path;
        }

        return path;
    }



    public static void CreateFile(string content,Transform parent)
    {
        //\AAAGame\Scripts\UI\UIVariables\SignUpForm.Variables.cs
        // 获取文件路径
        string path = Application.dataPath +"/AAAGame/Scripts/UI/UIVariables/"+parent.name+ ".Variables.cs";
Debug.LogError(path);
        if (File.Exists(path))
        {
            // 文件存在，清空内容
            File.WriteAllText(path, string.Empty);
            File.WriteAllText(path, content);
        }
        else
        {
            // 文件不存在，创建文件
            using (StreamWriter writer = File.CreateText(path))
            {
                writer.WriteLine(content);
            }
        }
    }
    
    public static void CreateFormFile(List<Transform> btns,Transform parent)
    {
        var sb= ZString.CreateStringBuilder();
        sb.Append("using Lean.Gui;using PlayFab;\r\nusing PlayFab.ClientModels;\r\nusing System.Text.RegularExpressions;\r\nusing TMPro;\r\nusing UnityEngine;\r\nusing UnityGameFramework.Runtime;\r\nusing Coo;");
        sb.AppendFormat("public partial class {0} : UIFormBase",parent.name);
        sb.Append("{");
        sb.Append(" protected override void OnInit(object userData)\r\n    {");
        sb.Append("base.OnInit(userData);");
        foreach (var item in btns)
        {
            sb.AppendFormat("{0}.OnClick.AddListener(On{1}Click);",item.name,item.name);
        }
        sb.Append("}");

        foreach (var item in btns)
        {
            sb.AppendFormat(" private void On{0}Click",item.name);
            sb.Append("()\r\n    {}");
        }


        sb.Append("protected override void OnOpen(object userData)\r\n    {\r\n        base.OnOpen(userData);\r\n    }");
        sb.Append("  protected override void OnClose(bool isShutdown, object userData)\r\n    {\r\n                  base.OnClose(isShutdown, userData);\r\n    }");
        sb.Append('}');
        
        //\AAAGame\Scripts\UI\UIVariables\SignUpForm.Variables.cs
        // 获取文件路径
        string path = Application.dataPath +"/AAAGame/Scripts/UI/"+parent.name+ ".cs";
        if (!File.Exists(path))
        {
            // 文件不存在，创建文件
            using (StreamWriter writer = File.CreateText(path))
            {
                writer.WriteLine(sb.ToString());
            }
        }
        else
        {
           
        }
    }
   static void ChangeLayer(Transform trans, string targetLayer)
    {
        if (LayerMask.NameToLayer(targetLayer)==-1)
        {
            Debug.Log("Layer中不存在,请手动添加LayerName");
            
            return;
        }
        //遍历更改所有子物体layer
        trans.gameObject.layer = LayerMask.NameToLayer(targetLayer);
        foreach (Transform child in trans)
        {
            ChangeLayer(child, targetLayer);
            Debug.Log(child.name +"子对象Layer更改成功！");
        }
    }

}