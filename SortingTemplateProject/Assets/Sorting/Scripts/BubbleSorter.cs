using System.Collections;
using Sorting; //access to library 

public class BubbleSorter : BaseSorter
{
    protected override IEnumerator Sort()
    {
        int nodeCount = nodes.Length; //how many nodes there are
        Node tempNode; //nodes = visual bar 

        //Loop over array 'length-sqaured' times
        for (int i = 0; i <= nodeCount - 2; i++)
        {
            for (int j = 0; j <= nodeCount - 2; j++)
            {
                //Is this node number greater than the one after it?
                if (nodes[j].Index > nodes[j + 1].Index)
                {
                    //It is, so swap the elements
                    //Store next element in temp variable
                    tempNode = nodes[j + 1]; //smaller node

                    //Set next element to current one
                    nodes[j + 1] = nodes[j]; //Array looks like this -> [5 , 5, 4, 3, 1] 

                    //Set this element to temp node
                    nodes[j] = tempNode;

                    // -- Visualisation -- //
                    StartFrame(j, j + 1); //Highlights these nodes and makes them purple
                    yield return null;
                    EndFrame(j, j + 1);
                    // -- End Visualisation -- //
                }
            }
        }
    }
}
