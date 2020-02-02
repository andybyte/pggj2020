//Create a folder named “Editor” (Right click in your Assets folder, Create>Folder)
//Put this script in the folder.
//This script adds fields to the Inspector of your GameObjects with the MyScript script attached. Edit the fields to change the layer and order number each Sprite belongs to.

using UnityEngine;
using UnityEditor;

// Custom Editor using SerializedProperties.

[CustomEditor(typeof(MyScript))]
public class MeshSortingOrderExample : Editor
{
    SerializedProperty m_Name;
    SerializedProperty m_Order;

    private SpriteRenderer rend;

    void OnEnable()
    {
        // Fetch the properties from the MyScript script and set up the SerializedProperties.
        m_Name = serializedObject.FindProperty("MyName");
        m_Order = serializedObject.FindProperty("MyOrder");
    }

    void CheckRenderer()
    {
        //Check that the GameObject you select in the hierarchy has a SpriteRenderer component
        if (Selection.activeGameObject.GetComponent<SpriteRenderer>())
        {
            //Fetch the SpriteRenderer from the selected GameObject
            rend = Selection.activeGameObject.GetComponent<SpriteRenderer>();
            //Change the sorting layer to the name you specify in the TextField
            //Changes to Default if the name you enter doesn't exist
            rend.sortingLayerName = m_Name.stringValue;
            //Change the order (or priority) of the layer
            rend.sortingOrder = m_Order.intValue;
        }
    }

    public override void OnInspectorGUI()
    {
        // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
        serializedObject.Update();
        //Create fields for each SerializedProperty
        EditorGUILayout.PropertyField(m_Name, new GUIContent("Name"));
        EditorGUILayout.PropertyField(m_Order, new GUIContent("Order"));
        //Update the name and order of the Renderer properties
        CheckRenderer();

        // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
        serializedObject.ApplyModifiedProperties();
    }
}