using Lean.Gui;
using Lean.Transition;
using Lean.Transition.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;



public class ButtonConvert:MonoBehaviour
    {
    [MenuItem("GameObject/转换组件/转成TapButton", false, 0)]
    static void ConvertToTapButton()
    {
        if (Selection.gameObjects != null && Selection.gameObjects.Length == 1)
        {
   
            var parentObj = Selection.gameObjects[0];
            var image =parentObj.GetComponent<Image>();
            var btn=parentObj.GetComponent<Button>();
         

          var prefab=  EditorGUIUtility.Load("TapButton.prefab");
         var newParentObj  = GameObject.Instantiate(prefab,parentObj.transform.parent) as GameObject;
            newParentObj.name=parentObj.name;
            var cap=newParentObj.transform.Find("Cap");
            var capImage = cap.GetComponent<Image>();
            capImage.sprite=image.sprite;

            var rect= parentObj.GetComponent<RectTransform>();
            var rectNew = newParentObj.GetComponent<RectTransform>();
            rectNew.position = rect.position;
            rectNew.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rect.rect.width);
            rectNew.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rect.rect.height);
        }
        else
        {
            Debug.LogError("请只选择一个物体进行复制路径;");
        }
    }

    [MenuItem("GameObject/转换组件/转成TouchButton", false, 0)]
    static void ConvertToTouchButton()
    {
        if (Selection.gameObjects != null && Selection.gameObjects.Length == 1)
        {

            var parentObj = Selection.gameObjects[0];
            var image = parentObj.GetComponent<Image>();
            var btn = parentObj.GetComponent<Button>();


            var prefab = EditorGUIUtility.Load("TouchButton.prefab");
            var newParentObj = GameObject.Instantiate(prefab, parentObj.transform.parent) as GameObject;
            newParentObj.name = parentObj.name;
            var cap = newParentObj.transform.Find("Cap");
            var capImage = cap.GetComponent<Image>();
            capImage.sprite = image.sprite;

            var rect = parentObj.GetComponent<RectTransform>();
            var rectNew = newParentObj.GetComponent<RectTransform>();
            rectNew.position = rect.position;
            rectNew.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rect.rect.width);
            rectNew.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rect.rect.height);
        }
        else
        {
            Debug.LogError("请只选择一个物体进行复制路径;");
        }
    }
    [MenuItem("GameObject/转换组件/转成Toggle", false, 0)]
    static void ConvertToToggle()
    {
        if (Selection.gameObjects != null && Selection.gameObjects.Length == 1)
        {

            var parentObj = Selection.gameObjects[0];
            var image = parentObj.GetComponent<Image>();
     


            var prefab = EditorGUIUtility.Load("Toggle.prefab");
            var newParentObj = GameObject.Instantiate(prefab, parentObj.transform.parent) as GameObject;
            newParentObj.name = parentObj.name;
            var on = newParentObj.transform.Find("Panel");
            var capImage = on.GetComponent<Image>();
            capImage.sprite = image.sprite;

            var rect = parentObj.GetComponent<RectTransform>();
            var rectNew = newParentObj.GetComponent<RectTransform>();
            rectNew.position = rect.position;
            rectNew.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rect.rect.width);
            rectNew.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rect.rect.height);
        }
        else
        {
            Debug.LogError("请只选择一个物体进行复制路径;");
        }
    }
    
 [MenuItem("GameObject/转换组件/转成LeanSwitch", false, 0)]
    static void ConvertToLeanSwitch()
    {
        if (Selection.gameObjects != null && Selection.gameObjects.Length == 1)
        {

            var parentObj = Selection.gameObjects[0];
            var image = parentObj.GetComponent<Image>();



            var prefab = EditorGUIUtility.Load("LeanSwitch.prefab");
            var newParentObj = GameObject.Instantiate(prefab, parentObj.transform.parent) as GameObject;
            newParentObj.name = parentObj.name;
     

            var rect = parentObj.GetComponent<RectTransform>();
            var rectNew = newParentObj.GetComponent<RectTransform>();
            rectNew.position = rect.position;
            rectNew.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rect.rect.width);
            rectNew.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rect.rect.height);
        }
        else
        {
            Debug.LogError("请只选择一个物体进行复制路径;");
        }
    }


    [MenuItem("GameObject/转换组件/转成PageView", false, 0)]
    static void ConvertToPageView()
    {
        if (Selection.gameObjects != null && Selection.gameObjects.Length == 1)
        {

            var parentObj = Selection.gameObjects[0];
            var image = parentObj.GetComponent<Image>();



            var prefab = EditorGUIUtility.Load("PageView.prefab");
            var newParentObj = GameObject.Instantiate(prefab, parentObj.transform.parent) as GameObject;
            newParentObj.name = parentObj.name;
           
       
       

            var rect = parentObj.GetComponent<RectTransform>();
            var rectNew = newParentObj.GetComponent<RectTransform>();
            rectNew.position = rect.position;
            rectNew.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rect.rect.width);
            rectNew.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rect.rect.height);
        }
        else
        {
            Debug.LogError("请只选择一个物体进行复制路径;");
        }
    }
    

          [MenuItem("GameObject/转换组件/转成TabMenu", false, 0)]
    static void ConvertToTabMenu()
    {
        if (Selection.gameObjects != null && Selection.gameObjects.Length == 1)
        {

            var parentObj = Selection.gameObjects[0];
            var image = parentObj.GetComponent<Image>();



            var prefab = EditorGUIUtility.Load("TabMenu.prefab");
            var newParentObj = GameObject.Instantiate(prefab, parentObj.transform.parent) as GameObject;
            newParentObj.name = parentObj.name;




            var rect = parentObj.GetComponent<RectTransform>();
            var rectNew = newParentObj.GetComponent<RectTransform>();
            rectNew.position = rect.position;
            rectNew.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rect.rect.width);
            rectNew.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rect.rect.height);
        }
        else
        {
            Debug.LogError("请只选择一个物体进行复制路径;");
        }
    }
}
