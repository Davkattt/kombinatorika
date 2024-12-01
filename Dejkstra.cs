using System;
using System.Collections.Generic;

class Dijkstra
{
    private int V; // Количество вершин
    private List<Tuple<int, int>>[] adj; // Список смежности для графа

    public Dijkstra(int v)
    {
        V = v;
        adj = new List<Tuple<int, int>>[V];
        for (int i = 0; i < V; i++)
            adj[i] = new List<Tuple<int, int>>();
    }

    // Функция для добавления ребра в граф
    public void AddEdge(int u, int v, int w)
    {
        adj[u].Add(new Tuple<int, int>(v, w)); // Добавляем v в список смежных к u
        adj[v].Add(new Tuple<int, int>(u, w)); // Если граф неориентированный
    }

    // Функция для выполнения алгоритма Дейкстры
    public void DijkstraAlgorithm(int start)
    {
        // Массив для хранения минимальных расстояний от начальной вершины
        int[] distances = new int[V];
        for (int i = 0; i < V; i++)
            distances[i] = int.MaxValue;
        distances[start] = 0;

        // Множество для хранения не обработанных вершин
        HashSet<int> visited = new HashSet<int>();

        for (int count = 0; count < V - 1; count++)
        {
            int u = MinDistance(distances, visited);
            visited.Add(u);

            foreach (var neighbor in adj[u])
            {
                int v = neighbor.Item1;
                int weight = neighbor.Item2;

                // Обновляем расстояния до соседних вершин
                if (!visited.Contains(v) && distances[u] != int.MaxValue && distances[u] + weight < distances[v])
                {
                    distances[v] = distances[u] + weight;
                }
            }
        }

        PrintSolution(distances);
    }

    // Функция для нахождения вершины с минимальным расстоянием
    private int MinDistance(int[] distances, HashSet<int> visited)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int v = 0; v < V; v++)
        {
            if (!visited.Contains(v) && distances[v] <= min)
            {
                min = distances[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    // Функция для вывода результата
    private void PrintSolution(int[] distances)
    {
        Console.WriteLine("Вершина \tМинимальное расстояние от начальной вершины");
        for (int i = 0; i < V; i++)
            Console.WriteLine(i + " \t\t " + distances[i]);
    }

    // Пример использования
    public static void Main(string[] args)
    {
        Dijkstra graph = new Dijkstra(9);
        graph.AddEdge(0, 1, 4);
        graph.AddEdge(0, 7, 8);
        graph.AddEdge(1, 2, 8);
        graph.AddEdge(1, 7, 11);
        graph.AddEdge(2, 3, 7);
        graph.AddEdge(2, 5, 4);
        graph.AddEdge(2, 8, 2);
        graph.AddEdge(3, 4, 9);
        graph.AddEdge(3, 5, 14);
        graph.AddEdge(4, 5, 10);
        graph.AddEdge(5, 6, 2);
        graph.AddEdge(6, 7, 1);
        graph.AddEdge(6, 8, 6);
        graph.AddEdge(7, 8, 7);

        graph.DijkstraAlgorithm(0); // Запускаем алгоритм с начальной вершиной 0
    }
}
