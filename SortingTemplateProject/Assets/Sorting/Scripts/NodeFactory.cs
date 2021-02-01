using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sorting
{
    public class NodeFactory : MonoBehaviour
    {
        private static NodeFactory factory = null;

        [SerializeField]
        private RectTransform canvasTransform;
        [SerializeField]
        private Node prefab;
        [SerializeField]
        private Color startColor = Color.red;
        [SerializeField]
        private Color endColor = Color.green;

        private int nodeCount = 0;
        private float scaleStep = 0;

        public static void Setup(GameObject _gameObject, int _nodeCount)
        {
            factory = _gameObject.GetComponent<NodeFactory>();
            factory.nodeCount = _nodeCount;

            factory.scaleStep = factory.canvasTransform.rect.height / (float)_nodeCount;
        }

        public static Node Create(int _index)
        {
            Node node = Object.Instantiate(factory.prefab, factory.transform);
            node.gameObject.name = string.Format("Node [{0}]", _index.ToString());

            Color nodeColor = Color.Lerp(factory.startColor, factory.endColor, Mathf.Clamp01((float)_index / (float)factory.nodeCount));
            float height = factory.scaleStep * (_index + 1);

            node.Setup(_index, height, nodeColor);

            return node;
        }
    }
}