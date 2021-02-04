using System.Collections;
using Sorting;
using Array = System.Array; //If there is non generic class or enum, can use part of namespace


public class CocktailSorter : BaseSorter
{
    protected override IEnumerator Sort()
    {
        int nodeCount = nodes.Length; //how many nodes there are
        Node tempNode; //nodes = visual bar 
        int maxArrayValue; //max value of array
        int minArrayValue; //min value of array

        //Loop through all nodes
        for (int i = 0; i <= nodeCount - 2; i++)
        {
            //Assign min and max values to loop
            minArrayValue = i;
            maxArrayValue = i;

            //Looping from low to high
            for (int j = 0; j <= nodeCount - 2; j++)
            {
                //Comapre index to current smallest index
                if (nodes[j].Index < nodes[minArrayValue].Index)
                {
                    minArrayValue = j;
                }
            }

            //Swap elements
            tempNode = nodes[minArrayValue];
            nodes[minArrayValue] = nodes[maxArrayValue];
            nodes[maxArrayValue] = tempNode;

            //Loop from high to low
            for (int j = i + 1; j < nodeCount; j--)
            {

            }





            // -- Visualisation -- //
            StartFrame(maxArrayValue, minArrayValue);
            yield return null;
            EndFrame(maxArrayValue, minArrayValue);
            // -- End Visualisation -- //
        }


    }
}
