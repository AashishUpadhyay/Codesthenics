using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitmanList
{
    class Graph
    {
        private bool _isMatrix;
        private int[,] _adjacencyMatrix;

        public Graph(int noOfVertices)
        {
            _adjacencyMatrix = new int[noOfVertices, noOfVertices];
            _isMatrix = true;
        }

        public void SetVertex(int noOfVertices)
        {
            _adjacencyMatrix = new int[noOfVertices, noOfVertices];
        }
    }
}
