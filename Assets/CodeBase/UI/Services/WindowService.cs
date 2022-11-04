using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace CodeBase.UI.Services
{
    [RequireComponent(typeof(UIDocument))]
    public class WindowService : MonoBehaviour
    {
        [SerializeField] private List<MenuItems> _menuItems;

        [SerializeField] private VisualTreeAsset _buttonTemplate;

        [Header("Transition setting")] [SerializeField]
        private int _distance;

        [SerializeField] private float _duration;
        [SerializeField] private float _appearanceDelay;
        [SerializeField] private EasingMode _easingMode;

        private VisualElement _container;
        private List<TimeValue> _durationValues;
        private StyleList<EasingFunction> _easingValues;

        private void Awake()
        {
            _container = GetComponent<UIDocument>().rootVisualElement.Q<VisualElement>("container");
        }

        private void Start()
        {
            _durationValues = new List<TimeValue> { new(_duration, TimeUnit.Second) };
            _easingValues = new StyleList<EasingFunction>(new List<EasingFunction> { new(_easingMode) });
            StartCoroutine(CreateMenu());
        }

        private IEnumerator CreateMenu()
        {
            yield return new WaitForSeconds(_appearanceDelay);

            foreach (MenuItems item in _menuItems)
            {
                VisualElement newElement = _buttonTemplate.CloneTree();
                Button button = newElement.Q<Button>("menu-button");

                button.text = item.ItemName;
                button.clicked += delegate { OnClick(item); };

                _container.Add(newElement);
                
                newElement.style.transitionDuration = _durationValues;
                newElement.style.transitionTimingFunction = _easingValues;
                newElement.style.marginTop = _distance;
                yield return null;
                newElement.style.marginTop = 0;
            }
        }

        private void OnClick(MenuItems item)
        {
            Debug.Log("Button clicked" + item.ItemName);
            item.Callback.Invoke();
        }
    }

    [Serializable]
    public class MenuItems
    {
        public string ItemName;
        public UnityEvent Callback;
    }
}