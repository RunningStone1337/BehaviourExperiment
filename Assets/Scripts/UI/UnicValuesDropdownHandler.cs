using BehaviourModel;
using Common;
using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI
{
    [Serializable]
    public class UnicValuesDropdownHandler<ContHandler, Content> 
        where ContHandler : IOptionsHandler, IValueChangedEventHandler
        where Content : IOption
    {
        [SerializeField] List<Content> availContent;
        [SerializeField] List<Content> selectedContent;
        [SerializeField] List<ContHandler> contentHandlers;
        private Action<ContHandler> OnValueChangedEvent { get; set; }
        public List<Content> SelectedContent { get=> selectedContent; }

        public bool HasFreeValues()
            => availContent.Count > 0;

        public void AddContentHandler(ContHandler ch, Action<ContHandler> valueChangedCallback = default)
        {
            contentHandlers.Add(ch);
            foreach (var f in availContent)
                ch.AddOption(f.OptionName);
            var content = availContent.FirstOrDefaultMatchContent(ch);
            ch.ValueObject = content;
            AddSelectedRemoveAvail(content);
            ResetAnotherContentHandlers(ch, content);
            ch.AddOnValueChangedCallback(OnDropdownSelectionChanged);
            OnValueChangedEvent += valueChangedCallback;
        }
        public void RemoveContentHandler(ContHandler ch)
        {
            var cont = selectedContent.FirstOrDefaultMatchContent(ch);
            var handlersExceptCh = contentHandlers.Where(x => !x.Equals(ch));
            foreach (var d in handlersExceptCh)
            {
                d.RemoveOnValueChangedCallbacks();
                d.AddOption(cont.OptionName);
                d.AddOnValueChangedCallback(OnDropdownSelectionChanged);
            }
            AddAvailRemoveSelected(cont);
            contentHandlers.Remove(ch);
        }

        private void ResetAnotherContentHandlers(ContHandler ch, Content excepdedContent)
        {
            var drops = contentHandlers.Where(x => !x.Equals(ch));
            foreach (var d in drops)
            {
                d.RemoveOnValueChangedCallbacks();
                d.RemoveOption(excepdedContent.OptionName);
                d.AddOnValueChangedCallback(OnDropdownSelectionChanged);
            }
        }
        private void AddAvailRemoveSelected(Content prevFeature)
        {
            selectedContent.Remove(prevFeature);
            availContent.Add(prevFeature);
        }
        private void OnDropdownSelectionChanged(int newIndex)
        {
            ContHandler sender = GetSenderWithFeatures(availContent, out Content newFeature, out Content prevFeature);
            AddAvailRemoveSelected(prevFeature);
            AddSelectedRemoveAvail(newFeature);
            var drops = contentHandlers.Where(x => !x.Equals(sender));
            foreach (var d in drops)
            {
                d.RemoveOnValueChangedCallbacks();
                d.AddOption(prevFeature.OptionName);
                d.RemoveOption(newFeature.OptionName);
                d.AddOnValueChangedCallback(OnDropdownSelectionChanged);
            }
            OnValueChangedEvent?.Invoke(sender);
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
                    prevContent = (Content)d.ValueObject;
                    sender.ValueObject = newContent;
                    break;
                }
            }
            return sender;
        }
        private void AddSelectedRemoveAvail(Content feature)
        {
            selectedContent.Add(feature);
            availContent.Remove(feature);
        }
    }
}