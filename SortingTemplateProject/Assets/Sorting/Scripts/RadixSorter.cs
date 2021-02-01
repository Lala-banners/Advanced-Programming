using System.Collections;
using Sorting;
using Array = System.Array; //If there is non generic class or enum, can use part of namespace

public class RadixSorter : BaseSorter
{
    //Sorts from the least significant digit:
    // 272, 45, 75, 81, 501, 2, 24, 66 = out of order!
    // 2, 4, 5, 5, 1, 1, 2, 4, 6 = takes digit & sorts
    // 81, 501, 272, (0)2, 24, 45, 75, 66
    // 501, 02, 24, 45, 66, 272, 75, 81 = takes digit & sorts
    // 8, 0, 7, 0, 2, 4, 7, 6
    // 501, 02, 024, 045, 066, 272, 075, 081
    // [02, 024, 045, 066, 075, 081, 272, 501] = sorted!

    protected override IEnumerator Sort()
    {
        int nodeCount = nodes.Length; //how many nodes there are
        int i, j;
        Node[] temp = new Node[nodes.Length];

        //Bitshifting = moving between 1s, 10s and 0s
        //For = F O R
        //First Value
        //Operator (condition)
        //Rate 
        for (int shift = 31; shift > -1; --shift)
        {
            //Reset j to 0
            j = 0;

            //Loop through whole array
            for (i = 0; i < nodeCount; ++i) //++i increments before loop, i++ increments after loop
            {
                //Determine if the bitshifted variable is above 0
                bool move = (nodes[i].Index << shift) >= 0;
                //Determining if there is an index that is above 0 - so move into next part of array

                //If shift equals 0
                if (shift == 0 ? !move : move)
                    nodes[i - j] = nodes[i];
                else
                    temp[j++] = nodes[i];  
            }

            //Copy the data to the temp array
            Array.Copy(temp, 0, nodes, nodes.Length - j, j);

            // -- Visualisation -- //
            StartFrame(0, 1);
            yield return null;
            EndFrame(0, 1);
            // -- End Visualisation -- //
        }
    }
}
