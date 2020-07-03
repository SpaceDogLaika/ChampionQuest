using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Actions
{
    [CreateAssetMenu(menuName = "Actions/MouseClickDetection")]
    public class MouseClickDetection : Action
    {
        public override void Execute(float d)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var results = Settings.GetUIObjects();

                foreach (RaycastResult result in results)
                {
                    IClickable clickable = result.gameObject.GetComponentInParent<IClickable>();

                    if (clickable != null)
                    {
                        clickable.OnClick();
                        break;
                    }
                }
            }
        }
    }
}
