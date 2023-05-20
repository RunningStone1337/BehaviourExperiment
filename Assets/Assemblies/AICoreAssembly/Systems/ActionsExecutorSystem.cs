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
        internal IEnumerator ExecureManuallySetted()
        {
            if (manualAction != null)
                yield return manualAction;
            manualAction = null;
        }

        /// <summary>
        /// React if has observable phenomena to react and current state is able to force change it
        /// </summary>
        public virtual IEnumerator ExecutePossible(BrainSystem<TAgent,TAction> brainSystem)
        {
            while (brainSystem.PhenomensToReact.Count > 0)
            {
                var selectedPhenom = brainSystem.SelectPhenomToReact(brainSystem.PhenomensToReact);

                if (brainSystem.TryGetActionsOnPhenom(selectedPhenom, out List<TAction> allReactions))
                {
                    //если реакция есть, необязательно, что её можно реализовать в текущий момент по определенным причинам
                    if (allReactions.Count == 0)
                    {
                        brainSystem.PhenomensToReact.Remove(selectedPhenom);
                        continue;
                    }
                    TAction selectedReaction;
                    do
                    {
                        selectedReaction = brainSystem.SelectActionFromList(allReactions);
                        yield return selectedReaction.TryPerformAction();
                        allReactions.Remove(selectedReaction);
                    } while (!selectedReaction.WasPerformed && allReactions.Count > 0);
                    brainSystem.PhenomensToReact.Remove(selectedPhenom);
                    break;
                }
                else
                    brainSystem.PhenomensToReact.Remove(selectedPhenom);
            }
        }
    }
}
