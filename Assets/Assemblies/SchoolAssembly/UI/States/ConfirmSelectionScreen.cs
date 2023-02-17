using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class ConfirmSelectionScreen : UIScreenBase
    {
        [SerializeField] private Button noButton;
        [SerializeField] private Text titleText;
        [SerializeField] private Button yesButton;

        public void AddNoButtonClickHandler(Action p)
        {
            noButton.onClick.AddListener(new UnityAction(p));
        }

        public void AddYesButtonClickHandler(Action clearEntrances)
        {
            yesButton.onClick.AddListener(new UnityAction(clearEntrances));
        }

        public void InitiateButtonsCallbacks(List<Action> yesActions, List<Action> noActions)
        {
            foreach (var e in yesActions)
                AddYesButtonClickHandler(e);
            AddYesButtonClickHandler(yesButton.onClick.RemoveAllListeners);

            foreach (var t in noActions)
                AddNoButtonClickHandler(t);
            AddNoButtonClickHandler(noButton.onClick.RemoveAllListeners);
        }
    }
}