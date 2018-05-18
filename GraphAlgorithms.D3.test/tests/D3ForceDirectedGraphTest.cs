using System;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GraphAlgorithms.D3.test
{
    using CharNode = WeightedNode<Char>;

    [TestFixture()]
    public class D3ForceDirectedGraphTest
    {
        private WeightedGraph<Char> TestCharGraph()
        {
            var graph = new WeightedGraph<Char>();

            var a = new CharNode('A');
            var b = new CharNode('B');

            graph.AddNode(a);
            graph.AddNode(b);

            graph.AddUndirectedEdge(a, b, 10);

            return graph;
        }

        [Test()]
        public void TestCase()
        {
            var d3 = new D3ForceDirectedGraph<Char>(TestCharGraph(),
                                       (character) => { return character.ToString(); }
                                      );
            string expected = "{\"nodes\":[{\"id\":\"A\",\"groupColor\":1},{\"id\":\"B\",\"groupColor\":1}],\"links\":[{\"source\":\"A\",\"target\":\"B\",\"value\":10.0}]}";
            string actual = JsonConvert.SerializeObject(d3);
            Assert.AreEqual(expected, actual);
        }
    }
}
