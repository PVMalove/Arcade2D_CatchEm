using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace CodeBase.UI
{
    public class ActorUI : MonoBehaviour
    {
        private VisualElement _bar;
        private VisualElement[] _hearts;

        private void Start()
        {
            _bar = GetComponent<UIDocument>().rootVisualElement.Q("container-health");
            _hearts = _bar.Children().ToArray();
        }

        public void AnimateBar()
        {
            VisualElement nextHeart = _hearts.Where(x => x.visible).LastOrDefault();
            nextHeart.style.visibility = Visibility.Hidden;
        }
    }
}