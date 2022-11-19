using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
public class ActionScheduler : MonoBehaviour
{
    IAction actionCancelling;

    public void StartAction(IAction action)
        {
            if (actionCancelling == action) return;
            if (actionCancelling != null)
            {
                actionCancelling.Cancel();
            }
            actionCancelling = action;
        }

        public void CancelCurrentAction()
        {
            StartAction(null);
        }
}
}

