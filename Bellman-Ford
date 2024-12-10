# Реализация алгоритма Беллмана-Форда на Python

class BellmanFord:
    def __init__(self, vertices, edges):
        self.V = vertices  # Количество вершин
        self.edges = edges  # Список рёбер: (u, v, w)

    def run(self, source):
        # Инициализация расстояний до всех вершин
        distance = [float("Inf")] * self.V
        distance[source] = 0

        # Расслабление всех рёбер |V|-1 раз
        for _ in range(self.V - 1):
            for u, v, w in self.edges:
                if distance[u] != float("Inf") and distance[u] + w < distance[v]:
                    distance[v] = distance[u] + w

        # Проверка на наличие цикла отрицательного веса
        for u, v, w in self.edges:
            if distance[u] != float("Inf") and distance[u] + w < distance[v]:
                print("Граф содержит цикл отрицательного веса")
                return None

        return distance


# Пример использования
if __name__ == "__main__":
    # Пример графа: вершины = 5, рёбра с весами
    vertices = 5
    edges = [
        (0, 1, -1),
        (0, 2, 4),
        (1, 2, 3),
        (1, 3, 2),
        (1, 4, 2),
        (3, 2, 5),
        (3, 1, 1),
        (4, 3, -3),
    ]

    bf = BellmanFord(vertices, edges)
    source_vertex = 0
    distances = bf.run(source_vertex)

    if distances:
        print(f"Кратчайшие расстояния от вершины {source_vertex}: {distances}")
