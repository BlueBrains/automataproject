using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Glee.Drawing;
using Microsoft.Glee.GraphViewerGdi;

namespace automataProject
{
    class Graph
    {
        private Microsoft.Glee.Drawing.Graph myGraph = new Microsoft.Glee.Drawing.Graph("Automata");
        private Node Current;
		private Node Final;
        public GViewer viewr = new GViewer();

        public Graph(string[][] Edges)
        { 
            foreach (var Edge in Edges)
            {
                myGraph.AddEdge(Edge[0],Edge[2],Edge[1]);
            }
            Node n1 = myGraph.FindNode(Edges[0][0]);
            n1.Attr.Color = Color.Aqua;
            Current = n1;
			Final = myGraph.FindNode("f");
			Final.Attr.Shape = Shape.DoubleCircle;
            viewr.Graph = myGraph;
            viewr.Dock = System.Windows.Forms.DockStyle.Fill;

        }

        public void Next(string NodeID)
        {
            Node t = myGraph.FindNode(NodeID);
            
            t.Attr.Color = Color.Aqua;
            Current.Attr.Color = Color.Black;
            Current = t;
            viewr.Graph = myGraph;
        }
            
	}
}
