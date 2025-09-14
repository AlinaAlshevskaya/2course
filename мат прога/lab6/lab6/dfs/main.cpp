#include <iostream>
#include <vector>
using namespace std;

void DFS(int node, vector<vector<int>>& graph, vector<bool>& visited, vector<int>& sequence, int& index) {
    // �������� ������� ����
    visited[node] = true;
    cout << "������� ����: " << node << endl;

    // ������� � ���������� ���� �� �������� ������������������
    if (index < sequence.size() - 1) {
        int nextNode = sequence[++index];
        if (!visited[nextNode]) {
            DFS(nextNode, graph, visited, sequence, index);
        }
    }
}

int main() {
    setlocale(LC_ALL, "rus");
    // ������� ��������� �����
    vector<vector<int>> graph = {
       {0, 1, 0, 0, 0, 0, 0},
        {0, 0, 0, 1, 1, 0, 0},
        {0, 0, 0, 0, 0, 0, 0},
        {0, 0, 1, 0, 0, 0, 1},
        {0, 0, 0, 0, 0, 0, 0},
        {0, 1, 0,0 , 0, 0, 0},
        {0, 0, 0, 0, 1, 1, 0}
    };

    // ������ ��� ������������ ���������� �����
    vector<bool> visited(graph.size(), false);

    // �������� ������������������ ������
    vector<int> sequence = { 0, 1, 4, 3, 6, 5, 2 };

    // ������ ��� ������������������
    int index = 0;

    // ������ DFS � ���������� ����
    cout << "����� � ������� �� �������� ������������������:" << endl;
    DFS(sequence[index], graph, visited, sequence, index);

    return 0;
}

