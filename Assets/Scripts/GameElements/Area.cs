using UnityEngine;
using System.Collections;

public class Area : MonoBehaviour
{
    public AreaLogic logic;

    public void OnDrop()
    {
        logic.Execute();
    }
}
