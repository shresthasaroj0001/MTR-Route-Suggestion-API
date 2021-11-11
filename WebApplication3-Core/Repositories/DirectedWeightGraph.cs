using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3_Core.Repositories
{
    public class Vertex
    {
        public int stationId;
        public int status;
        public int predecessor;
        public float pathlength;

        public Vertex(int id)
        {
            stationId = id;
        }
    }

    public class DirectedWeightGraph
    {
        private readonly int MAX_VERTICES = 99;
        int n = 0; //number of vertex
        int e = 0; //number of edges
        float[,] adj;
        Vertex[] vertexList;

        private readonly int TEMPORARY = 1;
        private readonly int PERMANENT = 2;
        private readonly int NIL = -1;
        private readonly int INFINITY = 99999;

        public DirectedWeightGraph()
        {
            adj = new float[MAX_VERTICES, MAX_VERTICES]; //max number of vertices
            vertexList = new Vertex[MAX_VERTICES];
        }

        public void Dijkstra(int s,int destinationVertex) //source
                                    // set predecessor and path length values of all the vertices
        {
            int v, c;
            //start of algorithm 
            //set all status temporary, path length infinity, predecesssor NIL
            for (v = 0; v < n; v++)
            {
                vertexList[v].status = TEMPORARY;
                vertexList[v].pathlength = INFINITY;
                vertexList[v].predecessor = NIL;
            }

            vertexList[s].pathlength = 0; //source length = 0

            while (true)
            {
                c = TempVertexMinPL(destinationVertex); //find temporary vertex with minimum path length

                if (c == NIL)
                    return;

                vertexList[c].status = PERMANENT;

                //check all the vertices that are adjacent to vertex c and are temporary
                for (v = 0; v < n; v++)
                {
                    if (IsAdjacent(c, v) && vertexList[v].status == TEMPORARY)
                    {
                        if (vertexList[c].pathlength + adj[c, v] < vertexList[v].pathlength)
                        {
                            vertexList[v].predecessor = c;
                            vertexList[v].pathlength = vertexList[c].pathlength + adj[c, v];
                        }
                    }
                }
            }

        }

        public int TempVertexMinPL(int destinationVertex)
        //return the temporary vertex with minimum path length and

        //return NIL if
        //there is no temporary vertex left or all the temporary vertices that are left have path length infinity
        {
            float min = INFINITY;
            int x = NIL;
            for (int v = 0; v < n; v++)
            {
                if (vertexList[destinationVertex].status != PERMANENT)
                {
                    if (vertexList[v].status == TEMPORARY && vertexList[v].pathlength < min)
                    {
                        min = vertexList[v].pathlength;
                        x = v;
                    }
                }
            }
            return x;
        }

        public List<int> FindPaths(int sourceVertex, int destinationVertex)
        {
            int s = GetIndex(sourceVertex); //
            int v = GetIndex(destinationVertex);

            Dijkstra(s,v);

            //Console.WriteLine("Source Vertex: " + source + "\n");

            List<int> shortestRoute = new List<int>();

            int u;
            while (v != s)
            {
                u = vertexList[v].predecessor;
                if (u == NIL)
                {
                    shortestRoute.Clear();
                    break;
                }
                shortestRoute.Add(vertexList[v].stationId);
                v = u;
            }
            return shortestRoute;
        }

        private int GetIndex(int s)
        {
            for (int i = 0; i < n; i++)
                if (vertexList[i].stationId == s)
                    return i;
            throw new System.InvalidOperationException("Invalid Vertex");
        }

        public void InsertVertex(int id)
        {
            vertexList[n++] = new Vertex(id);
        }

        private bool IsAdjacent(int u, int v)
        {
            return Convert.ToBoolean(adj[u, v]);
        }

        /*Insert an edge (s1,s2) */
        public void InsertEdge(int s1, int s2, float weight)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s2);

            if (u == v)
                throw new System.InvalidOperationException("Not a valid edge");
            if (adj[u, v] == weight)
                Console.Write("Edge already present");
            else
            {
                adj[u, v] = weight;
                e++;
            }
        }
    }
}
