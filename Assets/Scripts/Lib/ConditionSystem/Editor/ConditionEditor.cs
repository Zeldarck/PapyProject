using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Linq;
using System;

[CustomPropertyDrawer(typeof(Condition))]
public class ConditionEditor : PropertyDrawer
{
    List<string> m_allConditionCommandTypeStrings;

    List<System.Type> m_allConditionCommandType;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        m_allConditionCommandTypeStrings = new List<string>();
        m_allConditionCommandType = typeof(ConditionCommand).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(ConditionCommand))).ToList();

        foreach (System.Type type in m_allConditionCommandType)
        {
            m_allConditionCommandTypeStrings.Add(type.Name);
        }


        label = EditorGUI.BeginProperty(position, label, property);


        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;


        SerializedProperty Command = property.FindPropertyRelative("m_conditionCommand");


        Rect classRect = new Rect(position.x, position.y, position.width, EditorGUI.GetPropertyHeight(Command, label, true));



        UnityEngine.Object obj = Command.objectReferenceValue;
        ConditionCommand actualVal = (obj) as ConditionCommand;

        int currIndex = -1;
        if (actualVal != null)
        {
            for (int j = 0; j < m_allConditionCommandTypeStrings.Count; ++j)
            {
                if (m_allConditionCommandTypeStrings[j] == actualVal.GetType().Name)
                    currIndex = j;
            }
        }





        EditorGUI.BeginChangeCheck();


        int newIndex = EditorGUI.Popup(classRect, Command.displayName, currIndex, m_allConditionCommandTypeStrings.ToArray());

        if (EditorGUI.EndChangeCheck())
        {
            Command.objectReferenceValue = ScriptableObject.CreateInstance(m_allConditionCommandType[newIndex]);
            currIndex = newIndex;
        }



        ConditionCommand finalValue = Command.objectReferenceValue as ConditionCommand;

        if (finalValue != null)
        {
            EditorGUI.indentLevel = 1;

            SerializedObject childObj = new UnityEditor.SerializedObject(finalValue);


            SerializedProperty ite = childObj.GetIterator();
            float prevHeight = EditorGUI.GetPropertyHeight(Command, label, true);
            int i = 1;
            while (ite.NextVisible(true))
            {

                Rect newRect = new Rect(position.x, position.y + prevHeight + EditorGUIUtility.standardVerticalSpacing, position.width, EditorGUI.GetPropertyHeight(ite, label, true));
                prevHeight += newRect.height + EditorGUIUtility.standardVerticalSpacing;
                EditorGUI.PropertyField(newRect, ite);
                ++i;
            }


            childObj.ApplyModifiedProperties();

            List<string> methodsNames = new List<string>();
            MethodInfo[] methodInfos = m_allConditionCommandType[currIndex].GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);


            for (int j = 0; j < methodInfos.Length; ++j)
            {
                methodsNames.Add(methodInfos[j].Name);
            }

              Rect newRecte = new Rect(position.x, position.y + prevHeight + EditorGUIUtility.standardVerticalSpacing, position.width, EditorGUI.GetPropertyHeight(Command, label, true));


            int currIndex2 = -1;
            if (finalValue.Method != null)
            {
                for (int j = 0; j < methodsNames.Count; ++j)
                {
                    if (methodsNames[j] == finalValue.Method)
                        currIndex2 = j;
                }
            }


            EditorGUI.BeginChangeCheck();

            int newvalue2 = EditorGUI.Popup(newRecte, "Method", currIndex2, methodsNames.ToArray());
            prevHeight += EditorGUI.GetPropertyHeight(Command, label, true) + EditorGUIUtility.standardVerticalSpacing;

            SerializedProperty ite2 = childObj.GetIterator();

            while (ite2.Next(true))
            {

                if (ite2.displayName == "Method")
                {
                    break;
                }

            }

            if (EditorGUI.EndChangeCheck())
            {
                ite2.stringValue = methodsNames[newvalue2];

                childObj.ApplyModifiedProperties();
                currIndex2 = newvalue2;
            }

            if (currIndex2 >= 0)
            {

                MethodInfo method = methodInfos[currIndex2];

                
                for (int e = 0; e < method.GetParameters().Length ; e++)
                {
                    ParameterInfo parametter = method.GetParameters()[e];

                    SerializedProperty ite3 = childObj.GetIterator();

                    while (ite3.Next(true))
                    {

                        if (ite3.name == parametter.Name)
                        {
                            break;
                        }

                    }

                    Rect newRect = new Rect(position.x, position.y + prevHeight + EditorGUIUtility.standardVerticalSpacing, position.width, EditorGUI.GetPropertyHeight(ite3, label, true));
                    prevHeight += newRect.height + EditorGUIUtility.standardVerticalSpacing;
                    EditorGUI.PropertyField(newRect, ite3);

                }

            }

            childObj.ApplyModifiedProperties();




        }


        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();

    }

    private bool listVisibility = true;


    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {

        UnityEngine.Object command = property.FindPropertyRelative("m_conditionCommand").objectReferenceValue;
        if (command != null)
        {
            
            SerializedObject childObj = new UnityEditor.SerializedObject(property.FindPropertyRelative("m_conditionCommand").objectReferenceValue as ConditionCommand);

            SerializedProperty ite = childObj.GetIterator();

            float totalHeight = EditorGUI.GetPropertyHeight(property, label, true) + EditorGUIUtility.standardVerticalSpacing;
            totalHeight *= 2;
            while (ite.NextVisible(true))
            {
                totalHeight += EditorGUI.GetPropertyHeight(ite, label, true) + EditorGUIUtility.standardVerticalSpacing;
            }

            SerializedProperty method = childObj.FindProperty("method");
            MethodInfo m = (property.FindPropertyRelative("m_conditionCommand").objectReferenceValue as ConditionCommand).GetType().GetMethod(method.stringValue);
            if (m != null)
            {
                for (int e = 0; e < m.GetParameters().Length; e++)
                {
                    ParameterInfo parametter = m.GetParameters()[e];

                    ite = childObj.GetIterator();
                    while (ite.Next(true))
                    {

                        if (ite.name == parametter.Name)
                        {
                            totalHeight += EditorGUI.GetPropertyHeight(ite, label, true) + EditorGUIUtility.standardVerticalSpacing;
                            break;
                        }

                    }
                }
            }


            return totalHeight;
        }

        return EditorGUI.GetPropertyHeight(property.FindPropertyRelative("m_conditionCommand"), label, true);
    }




}
