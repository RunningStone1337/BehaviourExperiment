using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BehaviourModel
{
    public class AgentStatusBar : MonoBehaviour
    {
        [SerializeField] Transform agentTransform;
        [SerializeField] Animator barAnimator;
        [SerializeField] SpriteRenderer statusSprite;
        [SerializeField] float showTime;
        [SerializeField] TextMeshPro text;
        Coroutine barRoutine;
        public void Initiate(IStatusBarDataSource source)
        {
            statusSprite.sprite = source.StatusBarSprite;
            showTime = source.BarShowingTime;
            text.text = source.ToString();
        }
        private void FixedUpdate()
        {
            var rot = agentTransform.eulerAngles;
            transform.localEulerAngles = new Vector3(rot.x, rot.y, (-Mathf.Abs(rot.z))%360f);
        }
        public void Show()
        {
            barRoutine = StartCoroutine(ShowRoutine());
        }

        public void Hide()
        {
            barAnimator.Play("HideBar");
        }

        private IEnumerator ShowRoutine()
        {
            barAnimator.Play("ShowBar");
            yield return new WaitForSeconds(showTime);
            barAnimator.Play("HideBar");
        }
    }
}
