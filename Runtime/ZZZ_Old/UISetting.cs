using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    public abstract class UISetting<T> : MonoBehaviour where T : Selectable
    {
        [SerializeField] private T _selectable;

        public T selectable
        {
            get => _selectable;
            set
            {
                Unsubscribe();
                _selectable = value;
                Subscribe();
                UpdateView();
            }
        }

        protected virtual void OnEnable()
        {
            Subscribe();
            UpdateView();
        }

        protected virtual void OnDisable()
        {
            Unsubscribe();
        }

        protected virtual void OnValidate()
        {
            UpdateView();
        }

        protected virtual void Reset()
        {
            if(!TryGetComponent(out _selectable))
            {
#if UNITY_EDITOR
                if(UnityEditor.EditorUtility.DisplayDialog("UISetting", $"Do you want to create a new {typeof(T).Name} to couple this gameobject?", "Yes", "No"))
                {
                    UnityEditor.EditorApplication.ExecuteMenuItem($"GameObject/UI/{typeof(T).Name}");
                    _selectable = UnityEditor.Selection.activeGameObject.GetComponent<T>();
                }
#endif
            }
        }

        protected abstract void Subscribe();
        protected abstract void Unsubscribe();
        public abstract void UpdateView();
    }
}
