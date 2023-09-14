using System.Collections;
using System.Collections.Generic;

namespace BehaviourModel
{
    public class ActionsExecutorSystem<TAgent, TAction> : SystemBase<TAgent>
        where TAgent : IAgent
        where TAction : IAction
    {

        IEnumerator manualAction;
        public IEnumerator ManualAction { get => manualAction; set => manualAction = value; }
        internal IEnumerator ExecuteManuallySettedAction()
        {
            if (manualAction != null)
                yield return manualAction;
            manualAction = null;
        }

        /// <summary>
        /// React if has observable phenomena to react and current state is able to force change it
        /// </summary>
        public virtual IEnumerator ExecutePossibleAction(BrainSystem<TAgent,TAction> brain)
        {
            while (brain.PhenomensToReact.Count > 0)
            {
                var selectedPhenom = brain.SelectPhenomToReact(brain.PhenomensToReact);

                if (brain.TryGetActionsOnPhenom(selectedPhenom, out List<TAction> allReactions))
                {
                    //���� ������� ����, �������������, ��� � ����� ����������� � ������� ������ �� ������������ ��������
                    if (allReactions.Count == 0)
                    {
                        brain.PhenomensToReact.Remove(selectedPhenom);
                        continue;
                    }
                    TAction selectedReaction;
                    do
                    {
                        selectedReaction = brain.SelectActionFromList(allReactions);
                        yield return selectedReaction.TryPerformAction();
                        allReactions.Remove(selectedReaction);
                    } while (!selectedReaction.WasPerformed && allReactions.Count > 0);
                    brain.PhenomensToReact.Remove(selectedPhenom);
                    break;
                }
                else
                    brain.PhenomensToReact.Remove(selectedPhenom);
            }
        }
    }
}