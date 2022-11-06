using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace CodeBase.TEST
{
    public abstract class BaseScreen : MonoBehaviour
    {
        [SerializeField] protected UIDocument _document;
        
        protected VisualElement _root;

        protected virtual void Awake()
        {
            if (_document == null)
                _document = GetComponent<UIDocument>();
            
            SetVisualElements();
        }
        
        protected virtual void SetVisualElements()
        {
            if (_document != null)
                _root = _document.rootVisualElement;
        }
    }
}