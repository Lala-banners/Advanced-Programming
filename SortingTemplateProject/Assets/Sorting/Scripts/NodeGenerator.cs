using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sorting
{
    [RequireComponent(typeof(NodeFactory))]
    public class NodeGenerator : MonoBehaviour
    {
        public bool IsShuffled => isShuffled;
        public Node[] Nodes => nodes;

        [SerializeField, Range(1, 250)]
        private int nodeCount = 10;

        private Node[] nodes;
        private Node[] generatedNodes;

        private bool isShuffled = false;

        public void SetNodes(Node[] _sorted)
        {
            nodes = _sorted;
            for(int i = nodes.Length - 1; i >= 0; i--)
                nodes[i].transform.SetAsFirstSibling();
        }

        public void SetSelectedNodes(int _first, int _second, bool _selectedState)
        {
            nodes[_first].SetSelected(_selectedState);
            nodes[_second].SetSelected(_selectedState);
        }

        // Start is called before the first frame update
        void Awake()
        {
            generatedNodes = new Node[nodeCount];
            nodes = new Node[nodeCount];
            NodeFactory.Setup(gameObject, nodeCount);

            for(int i = 0; i < nodeCount; i++)
            {
               generatedNodes[i] = NodeFactory.Create(i);
            }
        }

        public void ShuffleNodes()
        {
            StartCoroutine(Shuffle(generatedNodes));
        }

        private IEnumerator Shuffle(Node[] _nodes)
        {
            List<int> indexes = new List<int>();
            for (int i = 0; i < nodeCount; i++)
                indexes.Add(i);

            int indexer = 0;
            while(indexes.Count > 0)
            {
                int randIndex = Random.Range(0, indexes.Count);
                nodes[indexer] = _nodes[indexes[randIndex]];

                nodes[indexer].transform.SetSiblingIndex(indexer);

                indexer++;

                indexes.RemoveAt(randIndex);

                yield return null;
            }

            isShuffled = true;
        }
    }
}