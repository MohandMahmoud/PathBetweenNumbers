using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{

    public static class PathBetweenNumbers
    {
        #region YOUR CODE IS HERE
        //Your Code is Here:
        //==================
        /// <summary>
        /// Given two numbers X and Y, find the min number of operations to convert X into Y
        /// Allowed Operations:
        /// 1.	Multiply the current number by 2 (i.e. replace the number X by 2 × X)
        /// 2.	Subtract 1 from the current number (i.e. replace the number X by X – 1)
        /// 3.	Append the digit 1 to the right of current number (i.e. replace the number X by 10 × X + 1).
        /// </summary>
        /// <param name="X">start number</param>
        /// <param name="Y">target number</param>
        /// <returns>min number of operations to convert X into Y</returns>
        public static int Find(int X, int Y)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
            // create a queue of states to explore
            var queue = new Queue<(int state, int steps)>();
            queue.Enqueue((X, 0));

            // set to keep track of visited states to avoid cycles
            var visited = new HashSet<int>();
            visited.Add(X);

            while (queue.Count > 0)
            {
                var (state, steps) = queue.Dequeue();

                // check if we have reached the target state
                if (state == Y)
                {
                    return steps;
                }

                // generate all possible next states
                int nextState1 = state * 2;
                int nextState2 = state - 1;
                int nextState3 = state * 10 + 1;

                // add unvisited next states to the queue
                if (nextState1 <= Y && !visited.Contains(nextState1))
                {
                    queue.Enqueue((nextState1, steps + 1));
                    visited.Add(nextState1);
                }
                if (nextState2 >= 1 && !visited.Contains(nextState2))
                {
                    queue.Enqueue((nextState2, steps + 1));
                    visited.Add(nextState2);
                }
                if (nextState3 <= Y && !visited.Contains(nextState3))
                {
                    queue.Enqueue((nextState3, steps + 1));
                    visited.Add(nextState3);
                }
            }

            // target state cannot be reached
            return -1;
        }
        #endregion

    }
}
