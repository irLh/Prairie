using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

// TODO: refactor into PrairieGUI.cs and remove this file
[CustomEditor(typeof(NextTwineNodeInteraction))]

// In a perfect world, this class would enable using a dropdown menu to select from
// available Twine nodes the next twine node to activate in an object with this
// interaction.  Unfortunately, this doesn't work just yet.
public class NextTwineNodeInteractionEditor : Editor
{
	NextTwineNodeInteraction nextTwineNode;
	public int index = 0;

	public override void OnInspectorGUI()
	{
		nextTwineNode = (NextTwineNodeInteraction)target;

		List<string> nodeNames = new List<string>();
		TwineNode[] nodes = FindObjectsOfType (typeof(TwineNode)) as TwineNode[];
		foreach (TwineNode node in nodes)
		{
			nodeNames.Add(node.name);
		}
		string[] nodeNamesArray = nodeNames.ToArray ();
		index = EditorGUILayout.Popup ("Available Nodes", index, nodeNamesArray);
		TwineNode nextNode = nextTwineNode.nextTwineNodeObject.GetComponent<TwineNode> ();
		nextNode = nodes [index];
	}

}
