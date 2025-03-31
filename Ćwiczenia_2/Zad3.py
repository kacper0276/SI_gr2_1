import math

class Node:
    def __init__(self, label, value=None, children=None):
        self.label = label
        self.value = value
        self.children = children if children is not None else []

def minimax(node, depth, alpha, beta, maximizing_player, path):
    if depth == 0 or not node.children:
        return node.value, path + [node.label]

    if maximizing_player:
        max_eval = -math.inf
        best_path = []
        for child in node.children:
            eval, child_path = minimax(child, depth - 1, alpha, beta, False, path + [node.label])
            if eval > max_eval:
                max_eval = eval
                best_path = child_path
            alpha = max(alpha, eval)
            if beta <= alpha:
                break
        return max_eval, best_path
    else:
        min_eval = math.inf
        best_path = []
        for child in node.children:
            eval, child_path = minimax(child, depth - 1, alpha, beta, True, path + [node.label])
            if eval < min_eval:
                min_eval = eval
                best_path = child_path
            beta = min(beta, eval)
            if beta <= alpha:
                break
        return min_eval, best_path

# Tree structure
root = Node("A", children=[
    Node("B", children=[Node("B1", 3), Node("B2", 12), Node("B3", 8)]),
    Node("C", children=[Node("C1", 2), Node("C2", 4), Node("C3", 6)]),
    Node("D", children=[Node("D1", 14), Node("D2", 5), Node("D3", 2)])
])

best_value, best_path = minimax(root, depth=3, alpha=-math.inf, beta=math.inf, maximizing_player=True, path=[])
print("Best Value:", best_value)
print("Best Path:", " -> ".join(best_path))
