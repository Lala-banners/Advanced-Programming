using System.Collections;
using UnityEngine;

namespace Sorting
{
    public abstract class BaseSorter : MonoBehaviour
    {
        [SerializeField]
        protected NodeGenerator generator;

        protected Node[] nodes;

        public void RunSorter()
        {
            if(!generator.IsShuffled)
                return;

            nodes = generator.Nodes;

            StartCoroutine(Sort());
        }

        protected abstract IEnumerator Sort();

        protected void StartFrame(int _first, int _second)
        {
            generator.SetSelectedNodes(_first, _second, true);
            generator.SetNodes(nodes);
        }

        protected void EndFrame(int _first, int _second)
        {
            generator.SetSelectedNodes(_first, _second, false);
        }
    }
}