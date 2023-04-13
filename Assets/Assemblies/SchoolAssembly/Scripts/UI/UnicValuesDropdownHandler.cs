using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI
{
    [Serializable]
    public class UnicValuesDropdownHandler<ContHandler, Content>
        where ContHandler : IKeysValuesHandler, IValueChangedEventHandler
        where Content : INameHandler
    {
        private readonly Dictionary<ContHandler, Content> selections = new Dictionary<ContHandler, Content>();
        [SerializeField] private List<Content> availContent;
        [SerializeField] private List<ContHandler> contentHandlers;
        [SerializeField] private List<Content> selectedContent;
        private Action<ContHandler> OnValueChangedEvent { get; set; }

        private void AddAvailRemoveSelected(Content cont)
        {
            selectedContent.Remove(cont);
            availContent.Add(cont);
        }

        private void AddSelectedRemoveAvail(Content cont)
        {
            selectedContent.Add(cont);
            availContent.Remove(cont);
        }

        private ContHandler GetSenderWithFeatures(List<Content> source, out Content newContent, out Content prevContent)
        {
            ContHandler sender = default;
            newContent = default;
            prevContent = default;
            foreach (var d in contentHandlers)
            {
                newContent = source.FirstOrDefaultMatchContent(d);
                if (newContent != null)
                {
                    sender = d;
                    prevContent = selections[d];
                    selections[d] = newContent;
                    break;
                }
            }
            return sender;
        }

        private void OnDropdownSelectionChanged(int newIndex)
        {
            var sender = GetSenderWithFeatures(availContent, out Content newFeature, out Content prevFeature);
            AddAvailRemoveSelected(prevFeature);
            AddSelectedRemoveAvail(newFeature);
            var drops = contentHandlers.Where(x => !x.Equals(sender));
            foreach (var d in drops)
            {
                d.RemoveOnValueChangedCallbacks();
                d.AddOption(prevFeature.Name, prevFeature);
                d.RemoveOption(newFeature.Name);
                d.AddOnValueChangedCallback(OnDropdownSelectionChanged);
            }
            OnValueChangedEvent?.Invoke(sender);
        }

        private void ResetAnotherContentHandlers(ContHandler ch, Content excepdedContent)
        {
            var drops = contentHandlers.Where(x => !x.Equals(ch));
            foreach (var d in drops)
            {
                d.RemoveOnValueChangedCallbacks();
                d.RemoveOption(excepdedContent.Name);
                d.AddOnValueChangedCallback(OnDropdownSelectionChanged);
            }
        }

        public List<Content> SelectedContent => selectedContent;

        public void AddContentHandler(ContHandler ch, Action<ContHandler> valueChangedCallback = default)
        {
            contentHandlers.Add(ch);
            foreach (var f in availContent)
                ch.AddOption(f.Name, f);
            var content = (Content)ch.SelectedOptionValue;
            selections.Add(ch, content);
            AddSelectedRemoveAvail(content);
            ResetAnotherContentHandlers(ch, content);
            ch.AddOnValueChangedCallback(OnDropdownSelectionChanged);
            OnValueChangedEvent += valueChangedCallback;
        }

        public bool HasFreeContent()
            => availContent.Count > 0;

        public void RemoveContentHandler(ContHandler ch)
        {
            var cont = (Content)ch.SelectedOptionValue;
            selections.Remove(ch);
            var handlersExceptCh = contentHandlers.Where(x => !x.Equals(ch));
            foreach (var d in handlersExceptCh)
            {
                d.RemoveOnValueChangedCallbacks();
                d.AddOption(cont.Name, cont);
                d.AddOnValueChangedCallback(OnDropdownSelectionChanged);
            }
            AddAvailRemoveSelected(cont);
            contentHandlers.Remove(ch);
        }
    }
}