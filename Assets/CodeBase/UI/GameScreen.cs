using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace CodeBase.UI
{
    public class GameScreen : MonoBehaviour
    {
        [SerializeField] private string _loseScreenName = "GameLoseScreen";
        
        private VisualElement _loseScreen;
        private UIDocument _gameScreen;

        private void OnEnable()
        {
            SetVisualElements();
            GameOver.GameLost += OnGameLost;
        }

        private void SetVisualElements()
        {
            _gameScreen = GetComponent<UIDocument>();
            VisualElement rootElement = _gameScreen.rootVisualElement;
            _loseScreen = rootElement.Q(_loseScreenName);
        }

        private void OnDisable()
        {
            GameOver.GameLost -= OnGameLost;
        }

        private void OnGameLost()
        {
            StartCoroutine(GameLostRoutine());
        }

        private IEnumerator GameLostRoutine()
        {
            yield return new WaitForSeconds(2);
            ShowVisualElement(_loseScreen, true);
        }
        
        void ShowVisualElement(VisualElement visualElement, bool state)
        {
            if (visualElement == null)
                return;

            visualElement.style.display = (state) ? DisplayStyle.Flex : DisplayStyle.None;
        }
    }
}