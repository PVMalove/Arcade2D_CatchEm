using System;
using UnityEngine.Events;

namespace CodeBase.UI.Services
{
    [Serializable]
    public class MenuItems
    {
        public string ItemName;
        public UnityEvent Callback;
    }
}