using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class MergeSort : ISortingAlgorithm
    {
        public int[] Partition(int[] A, int startIndex, int endIndex)
        {
            //TODO #1: return a new array with all elements in A from index startIndex to endIndex (both included): A[startIndex..endIndex]

            int[] partition = new int[endIndex-startIndex+1];
            int cant=0;
            for (int i = startIndex; i <= endIndex; i++)
            {
                partition[cant]=A[i];
                cant++;
            }
            return partition;
        }

        public void MergePartitions(int[] A, int[] leftPartition, int[] rightPartition)
        {
            //TODO #2: Merge in A the two partitions sorting them
            int total = leftPartition.Length + rightPartition.Length;
            int left = 0;
            int right = 0;
            for (int i = 0; i < total; i++)
            {
                if(left < leftPartition.Length && right < rightPartition.Length)
                {
                    if (leftPartition[left] < rightPartition[right])
                    {
                        A[i] = leftPartition[left];
                        left++;
                    }
                    else
                    {
                        A[i] = rightPartition[right];
                        right++;
                    }
                }
                else if (left < leftPartition.Length)
                {
                    A[i] = leftPartition[left];
                    left++;
                }
                else
                {
                    A[i] = rightPartition[right];
                    right++;
                }
                
            }
        }

        public void Sort(int[] A)
        {
            //TODO #3: Implement MergeSort using the methods above
            int half = A.Length / 2;
            int[] left = Partition(A, 0, half-1);
            int[] right = Partition(A, half, A.Length-1);
            if(left.Length> 1)
            {
                Sort(left);
            }
            if(right.Length> 1)
            {
                Sort(right);
            }
            MergePartitions(A, left, right);

        }

        public bool CheckIsCorrect()
        {
            int n = 10;
            int[] A = Utils.CreateIntArray(n);

            Console.WriteLine("1.1 Checking Partition()");
            if (!Utils.IsPartitionCorrect(A, Partition(A, 0, 3), 0, 3))
            {
                Console.WriteLine("FAILED");
                return false;
            }
            if (!Utils.IsPartitionCorrect(A, Partition(A, 1, 1), 1, 1))
            {
                Console.WriteLine("FAILED");
                return false;
            }
            Console.WriteLine("PASSED");
            Console.WriteLine("1.2. Checking MergePartitions()");
            int[] leftPartition = new int[3] { 1, 4, 6 };
            int[] rightPartition = new int[3] { 2, 3, 7 };
            int[] merged = new int[6] { 1, 4, 6, 2, 3, 7 };
            MergePartitions(merged, leftPartition, rightPartition);
            if (!Utils.IsOrdered(merged))
            {
                Console.WriteLine("FAILED");
                return false;
            }
            Console.WriteLine("PASSED");
            return true;
        }
    }
}
