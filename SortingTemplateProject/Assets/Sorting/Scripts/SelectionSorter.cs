using System.Collections;
using Sorting;

public class SelectionSorter : BaseSorter
{
    protected override IEnumerator Sort()
    {
        int nodeCount = nodes.Length; //how many nodes there are
        int smallest; //Part of item index, NOT THE ACTUAL VALUE
        Node tempNode;
        int old; //Visualisation ONLY

        //Looping through all elements
        for (int i = 0; i < nodeCount - 1; i++)
        {
            //Assign smallest number to this loops iterator value 
            smallest = i;
            old = i;

            //Loop from this iteration to the end
            for (int j = i + 1; j < nodeCount; j++)
            {
                //Compare this index to the current smallest index item
                if (nodes[j].Index < nodes[smallest].Index)
                {
                    smallest = j;
                }
            }

            //Swap the elements
            tempNode = nodes[smallest];
            nodes[smallest] = nodes[old];
            nodes[old] = tempNode;

            // -- Visualisation -- //
            StartFrame(old, smallest);
            yield return null;
            EndFrame(old, smallest);
            // -- End Visualisation -- //
        }

    }
}
