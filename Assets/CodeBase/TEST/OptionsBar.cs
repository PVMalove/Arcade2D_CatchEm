using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace CodeBase.TEST
{
    public class OptionsBar : BaseScreen
    {
        private const float _lerpTime = 0.6f;
        private const string ScoresLabelName = "scores-count";

        private Label _scoresLabel;

        private void OnEnable()
        {
            GameDataManager.ScoresUpdated += OnScoresUpdated;
        }
        
        private void OnDisable()
        {
            GameDataManager.ScoresUpdated -= OnScoresUpdated;
        }

        protected override void SetVisualElements()
        {
            base.SetVisualElements();
            _scoresLabel = _root.Q<Label>(ScoresLabelName);
        }

        private void OnScoresUpdated(GameData gameData)
        {
            SetScores(gameData.Scores);
        }


        private void SetScores(int scores)
        {
            int startValue = (int) Int32.Parse(_scoresLabel.text);
            StartCoroutine(LerpRoutine(_scoresLabel, startValue, scores, _lerpTime));
        }

        private IEnumerator LerpRoutine(Label label, int startValue, int endValue, float duration)
        {
            float lerpValue = (float) startValue;
            float t = 0f;
            label.text = string.Empty;

            while (Mathf.Abs((float) endValue - lerpValue) > 0.05f)
            {
                t += Time.deltaTime / _lerpTime;

                lerpValue = Mathf.Lerp(startValue, endValue, t);
                label.text = lerpValue.ToString("0");
                yield return null;
            }
            label.text = endValue.ToString();
        }
    }
}