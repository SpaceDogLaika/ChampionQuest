using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Actions/MouseOverDetection")]
public class MouseOverDetection : Action
{
    public override void Execute(float d)
    {
        var results = Settings.GetUIObjects();

        IClickable clickable = null;

        foreach (RaycastResult result in results)
        {
            clickable = result.gameObject.GetComponentInParent<IClickable>();

            if (clickable != null)
            {
                clickable.OnHighlight();
                break;
            }
        }
    }
}
