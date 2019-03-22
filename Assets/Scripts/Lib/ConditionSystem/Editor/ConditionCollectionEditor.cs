using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Linq;

[CustomPropertyDrawer(typeof(ConditionCollection))]
public class ConditionCollectionEditor : PropertyDrawer
{
    /*public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Slider(2, -1, 3);
    }*/
    List<string> allTypeStrings;

   // System.Management.ManagementObjectCollection allTypes;
   /* ManagementClass c =
    new ManagementClass("Interactable");*/

    List<System.Type> test;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        allTypeStrings = new List<string>();
     //   allTypes = c.GetSubclasses();


        test = typeof(Interactable).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Interactable))).ToList();


        foreach (System.Type type in test)
        {
            allTypeStrings.Add(type.Name);
        }


        label = EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        Rect classRect = new Rect(position.x, position.y, position.width, position.height);

        //Debug.Log(property.);

        Interactable actualVal = (property.FindPropertyRelative("test").objectReferenceValue) as Interactable;
        int currIndex = -1;
        if (actualVal != null)
        {
            for (int j = 0; j < allTypeStrings.Count; ++j)
            {
                if (allTypeStrings[j] == actualVal.GetType().Name)
                    currIndex = j;
            }
        }
        MethodInfo[] methodInfos = test[0].GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        for(int i = 0; i < methodInfos.Length; ++i)
        {
            Debug.Log(methodInfos[i].Name);
        }


        EditorGUI.BeginChangeCheck();
       // Debug.Log(allTypeStrings.Count);
        int newIndex = EditorGUI.Popup(classRect, currIndex, allTypeStrings.ToArray());
        Debug.Log(newIndex);
        /* if (EditorGUI.EndChangeCheck())
         {
             property.objectReferenceValue = ScriptableObject.CreateInstance(test[newIndex]);
             //actualVal = ScriptableObject.CreateInstance(allTypes[newIndex]) as Command;
             Debug.Log(property.objectReferenceValue);
           //  Debug.Log("Changed to " + (property.objectReferenceValue as System.Object as Interactable).commandName);
         }*/

        //  string finalValue = null;// property.objectReferenceValue;

        /* if (finalValue != null)
         {
             EditorGUI.indentLevel = 1;

             SerializedObject childObj = new UnityEditor.SerializedObject(finalValue);

             Debug.Log("Child number is " + childObj.GetIterator().displayName);
             SerializedProperty ite = childObj.GetIterator();
             int i = 1;
             while (ite.NextVisible(true))
             {
                 Debug.Log("Child is " + ite.displayName);
                 Rect newRect = new Rect(position.x, position.y + i * 20, position.width, position.height);
                 EditorGUI.PropertyField(newRect, ite);
                 ++i;
             }
             childObj.ApplyModifiedProperties();
         }*/

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();

    }


}
