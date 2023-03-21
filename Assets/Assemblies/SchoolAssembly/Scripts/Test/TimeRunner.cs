using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BehaviourModel
{
    public class TimeRunner : MonoBehaviour
    {
        [SerializeField] Text text;
        [SerializeField] Text textUpd;
        [SerializeField] Text textFixUpd;
        int updCounter;
        int fixUpdCounter;
        private void Start()
        {
            StartCoroutine(TimeRunnerRoutineMins());
        }

        private IEnumerator TimeRunnerRoutine()
        {
            for (int min = 0; min < 100; min++)
            {
                for (int sec = 0; sec < 60; sec++)
                {
                    yield return new WaitForSeconds(1f);
                    text.text = $"{min * 60 + sec}";
                }
            }
        }
        private IEnumerator TimeRunnerRoutineMins()
        {
            for (int min = 0; min < 100; min++)
            {
                yield return new WaitForSeconds(60f);
                text.text = $"{min }";
            }
        }
        private void Update()
        {
            updCounter++;
            textUpd.text = updCounter.ToString();
        }
        private void FixedUpdate()
        {
            fixUpdCounter++;
            textFixUpd.text = fixUpdCounter.ToString();
        }
    }
}
