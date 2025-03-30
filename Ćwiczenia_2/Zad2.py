import heapq
from copy import deepcopy


class Puzzle8:
    def __init__(self, state, parent=None, move=None, depth=0):
        self.state = state
        self.parent = parent
        self.move = move
        self.depth = depth
        self.cost = self.depth + self.heuristic()

    def __lt__(self, other):
        return self.cost < other.cost

    def find_empty(self):
        for i in range(3):
            for j in range(3):
                if self.state[i][j] == 0:
                    return i, j

    def heuristic(self):
        goal = {1: (0, 0), 2: (0, 1), 3: (0, 2),
                4: (1, 0), 5: (1, 1), 6: (1, 2),
                7: (2, 0), 8: (2, 1), 0: (2, 2)}
        return sum(abs(i - goal[val][0]) + abs(j - goal[val][1])
                   for i, row in enumerate(self.state)
                   for j, val in enumerate(row) if val != 0)

    def get_neighbors(self):
        neighbors = []
        x, y = self.find_empty()
        moves = {'Up': (x - 1, y), 'Down': (x + 1, y), 'Left': (x, y - 1), 'Right': (x, y + 1)}

        for move, (nx, ny) in moves.items():
            if 0 <= nx < 3 and 0 <= ny < 3:
                new_state = deepcopy(self.state)
                new_state[x][y], new_state[nx][ny] = new_state[nx][ny], new_state[x][y]
                neighbors.append(Puzzle8(new_state, self, move, self.depth + 1))

        return neighbors

    def reconstruct_path(self):
        path, states, node = [], [], self
        while node:
            states.append(node.state)
            if node.move:
                path.append(node.move)
            node = node.parent
        return path[::-1], states[::-1]

    def is_goal(self):
        return self.state == [[1, 2, 3], [4, 5, 6], [7, 8, 0]]


def print_state(state):
    for row in state:
        print(" ".join(str(x) if x != 0 else " " for x in row))
    print()


def a_star(initial_state):
    start = Puzzle8(initial_state)
    open_list = []
    heapq.heappush(open_list, start)
    visited = set()

    while open_list:
        current = heapq.heappop(open_list)
        if current.is_goal():
            return current.reconstruct_path()

        visited.add(tuple(map(tuple, current.state)))
        for neighbor in current.get_neighbors():
            if tuple(map(tuple, neighbor.state)) not in visited:
                heapq.heappush(open_list, neighbor)

    return None


initial_state = [[0, 1, 3], [4, 2, 5], [7, 8, 6]]
print("Initial state:")
print_state(initial_state)
solution, states = a_star(initial_state)


if solution:
    print("Solution found!")
    for move, state in zip(solution, states[1:]):
        print(f"Move: {move}")
        print_state(state)
else:
    print("No solution found.")
