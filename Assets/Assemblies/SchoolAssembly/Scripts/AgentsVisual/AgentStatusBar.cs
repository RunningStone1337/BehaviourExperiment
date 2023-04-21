using System.Collections;
#if UNITY_EDITOR
using TMPro;
#endif
using UnityEngine;

namespace BehaviourModel
{
    public class AgentStatusBar : MonoBehaviour
    {
        [SerializeField] Transform movedCloudTransform;
        [SerializeField] Transform agentTransform;
        [SerializeField] Animator barAnimator;
        [SerializeField] SpriteRenderer statusSprite;
        [SerializeField] float showTime;
#if UNITY_EDITOR
        [SerializeField] TextMeshPro text;
#endif
        Coroutine barRoutine;
        public void Initiate(IStatusBarDataSource source)
        {
            statusSprite.sprite = source.StatusBarSprite;
            showTime = source.BarShowingTime;
#if UNITY_EDITOR
            text.text = source.ToString();
#endif
        }
        private void FixedUpdate()
        {
            var rot = agentTransform.eulerAngles;
            movedCloudTransform.localEulerAngles = new Vector3(rot.x, rot.y, (-Mathf.Abs(rot.z))%360f);
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
