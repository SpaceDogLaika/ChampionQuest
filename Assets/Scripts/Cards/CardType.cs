using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardType : ScriptableObject
{
    public string typeName;

    public virtual void OnSetType(CardViz viz)
    {
        Element element = Settings.GetResourcesManager().typeElement;
        CardVizProperties type = viz.GetProperty(element);
        type.text.text = typeName;
    }

}
