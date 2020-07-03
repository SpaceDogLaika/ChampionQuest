using UnityEngine;
using UnityEngine.UI;

namespace SO.UI
{
    class UpdateTextFromPhase : UIPropertyUpdater
    {
        public PhaseVariable currentPhase;
        public Text targetText;

        /// <summary>
        /// Use this to update a text UI element based on the target string variable
        /// </summary>
        public override void Raise()
        {
            targetText.text = currentPhase.value.phaseName;
        }
    }
}
