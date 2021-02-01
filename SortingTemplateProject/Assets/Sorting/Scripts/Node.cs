using UnityEngine;
using UnityEngine.UI;

namespace Sorting
{
    [RequireComponent(typeof(LayoutElement), typeof(Image))]
    public class Node : MonoBehaviour
    {
        public int Index => index;

        private int index = 0;
        private LayoutElement layout;
        private new Image renderer;

        private Color startColor;
        private Color selectedColor = Color.blue;

        public void Setup(int _index, float _height, Color _color)
        {
            index = _index;

            layout = gameObject.GetComponent<LayoutElement>();
            layout.preferredHeight = _height;

            renderer = gameObject.GetComponent<Image>();
            renderer.color = _color;
            startColor = _color;
        }

        public void SetSelected(bool _isSelected)
        {
            renderer.color = _isSelected ? selectedColor : startColor;
        }
    }
}