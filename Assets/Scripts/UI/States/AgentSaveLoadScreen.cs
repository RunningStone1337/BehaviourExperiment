using BehaviourModel;
using Common;
using SerializationModule;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UI.CanvasController;

namespace UI
{
    public class AgentSaveLoadScreen : UIScreenBase
    {
        [SerializeField] private AgentCreationScreen agentCreationScreen;
        [SerializeField] private ContentOrderHandler contentOrderHandler;
        [SerializeField] private RectTransform contentTransform;
        [SerializeField] private List<AgentDataSaveLoadView> existAgents;
        [SerializeField] private AgentDataSaveLoadView newAgentCreationView;
        [SerializeField] private Button saveButton;

        private AgentDataSaveLoadView CreateNewViewForData((AgentRawData agent, string path) ad)
        {
            var saveLoadView = SceneDataStorage.Storage.AgentDataSaveLoadViewPrafab;
            var view = Instantiate(saveLoadView, contentTransform).GetComponent<AgentDataSaveLoadView>();
            view.Initiate(ad.agent, ad.path);
            existAgents.Add(view);
            contentOrderHandler.ReorderContent();
            return view;
        }

        private void DeleteExistingAgent(string path)
        {
            var serializeUtil = new SerializeUtility();
            serializeUtil.RemoveAgent(path);
        }

        private void LoadAgent()
        {
            var data = ((AgentDataSaveLoadView)ActiveComponent).AgentRawData;
            agentCreationScreen.InitiateState<PupilAgent>(data);
            BeforeChangeState();
        }

        /// <summary>
        /// Удаляет выбранного агента и создаёт нового с текущими парамерами конфигуратора.
        /// </summary>
        private void OverwriteSelectedAgent()
        {
            var actView = (AgentDataSaveLoadView)ActiveComponent;
            DeleteExistingAgent(actView.DataPath);
            AgentRawData agent = new AgentRawData();
            agent.Initiate(agentCreationScreen);
            var path = TrySave(agent);
            if (path != null)
                actView.Initiate(agent, path);
            else
            {
                Destroy(actView.gameObject);
                existAgents.RemoveAll(x => x == null);
            }
        }

        private void TryOverwriteAgent()
        {
            var confirm = Controller.ConfirmSelectionScreen;
            confirm.InitiateState();
            confirm.InitiateButtonsCallbacks(
                new List<Action>() {
                        OverwriteSelectedAgent,
                        confirm.BeforeChangeState,
                        ()=>{ ActiveComponent = null;}
                },
                new List<Action>()
                {
                        confirm.BeforeChangeState,
                        ()=>{ ActiveComponent = null;}
                }
                );
        }

        private string TrySave(AgentRawData agent)
        {
            var serializeUtil = new SerializeUtility();
            var path = serializeUtil.SaveAgent(agent, agent.AgentName);
            return path;
        }

        private void TrySaveNewAgent()
        {
            ///TODO проверка на существование файла с текущим именем в конфигураторе
            var agent = new AgentRawData();
            agent.Initiate(agentCreationScreen);
            var path = TrySave(agent);
            if (path != null)
            {
                var newView = CreateNewViewForData((agent, path));
                ActiveComponent = newView;
                BeforeChangeState();
            }
            else
                ActiveComponent = null;
        }

        public override ISelectableUIComponent ActiveComponent
        {
            get => selectedUIComponent;
            set
            {
                base.ActiveComponent = value;
                if (ActiveComponent == null)
                    saveButton.interactable = false;
                else
                    saveButton.interactable = true;
            }
        }

        public override void BeforeChangeState()
        {
            base.BeforeChangeState();
            foreach (var ea in existAgents)
            {
                if (ea != null)
                    Destroy(ea.gameObject);
            }
            existAgents.Clear();
            ActiveComponent = null;
        }

        public override void InitiateState()
        {
            base.InitiateState();
            var serializeUtil = new SerializeUtility();
            var agentsData = serializeUtil.LoadDataList<AgentRawData>();
            foreach (var ad in agentsData)
                CreateNewViewForData(ad);
            contentOrderHandler.ReorderContent();
        }

        public void OnLoadButtonClick()
        {
            if (ActiveComponent != null)
                LoadAgent();
        }

        public void OnSaveButtonClick()
        {
            if (newAgentCreationView.Equals(ActiveComponent))
                TrySaveNewAgent();
            else if (ActiveComponent != null)
                TryOverwriteAgent();
        }
    }
}