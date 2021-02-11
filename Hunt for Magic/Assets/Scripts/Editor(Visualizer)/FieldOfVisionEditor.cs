using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AdvancedAI))]
public class FieldOfVisionEditor : Editor
{
    void onSceneGui()
    {
        AdvancedAI fow = (AdvancedAI)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.radius);
        Vector3 ViewAngleA = fow.DirFromAngle(-fow.angle / 2, false);
        Vector3 ViewAngleB = fow.DirFromAngle(fow.angle / 2, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + ViewAngleA * fow.radius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + ViewAngleB  * fow.radius);

        Handles.color = Color.red;
        foreach(Transform visibleTarget in fow.visibleTarget)
        {
            Handles.DrawLine(fow.transform.position, visibleTarget.position);
        }
    }
}
