using System;
using System.Collections.Generic;

namespace GraphAlgorithms.D3
{
    public struct D3Node
    {
        public readonly string id;
        public readonly int groupColor;
        public D3Node(string id, int groupColor = 1) {
            this.id = id;
            this.groupColor = groupColor;
        }
    }

    public struct D3Link
    {
        public readonly string source;
        public readonly string target;
        public readonly double value;
        public D3Link(string source, string target, double value) {
            this.source = source;
            this.target = target;
            this.value = value;
        }
    }

    public struct D3ForceDirectedGraph<CONTENT> where CONTENT : IEquatable<CONTENT>
    {
        public readonly D3Node[] nodes;
        public readonly D3Link[] links;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:D3Manager.D3Graph`1"/> struct.
        /// </summary>
        /// <param name="graph">Graph.</param>
        /// <param name="converter">Transforms the information in the WeightedNode into </param>
        public D3ForceDirectedGraph(WeightedGraph<CONTENT> graph, Func<CONTENT, string> converter)
        {
            var nList = new List<D3Node>();
            graph.BFS(node => nList.Add(new D3Node(id: converter(node.Content))));

            var lList = new List<D3Link>();
            var edges = graph.UndirectedEdges();

            foreach (var edge in edges)
            {
                lList.Add(new D3Link(converter(edge.Item1.Content), converter(edge.Item2.Content), edge.Item3));
            }
            nodes = nList.ToArray();
            links = lList.ToArray();
        }
    }
}
