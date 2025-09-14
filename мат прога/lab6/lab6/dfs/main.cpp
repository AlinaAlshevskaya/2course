#include <iostream>
#include <vector>
using namespace std;

void DFS(int node, vector<vector<int>>& graph, vector<bool>& visited, vector<int>& sequence, int& index) {
    // Посетить текущий узел
    visited[node] = true;
    cout << "Посещён узел: " << node << endl;

    // Перейти к следующему узлу по заданной последовательности
    if (index < sequence.size() - 1) {
        int nextNode = sequence[++index];
        if (!visited[nextNode]) {
            DFS(nextNode, graph, visited, sequence, index);
        }
    }
}

int main() {
    setlocale(LC_ALL, "rus");
    // Матрица смежности графа
    vector<vector<int>> graph = {
       {0, 1, 0, 0, 0, 0, 0},
        {0, 0, 0, 1, 1, 0, 0},
        {0, 0, 0, 0, 0, 0, 0},
        {0, 0, 1, 0, 0, 0, 1},
        {0, 0, 0, 0, 0, 0, 0},
        {0, 1, 0,0 , 0, 0, 0},
        {0, 0, 0, 0, 1, 1, 0}
    };

    // Вектор для отслеживания посещённых узлов
    vector<bool> visited(graph.size(), false);

    // Заданная последовательность обхода
    vector<int> sequence = { 0, 1, 4, 3, 6, 5, 2 };

    // Индекс для последовательности
    int index = 0;

    // Запуск DFS с начального узла
    cout << "Обход в глубину по заданной последовательности:" << endl;
    DFS(sequence[index], graph, visited, sequence, index);

    return 0;
}

