import math
class Node:
    def __init__(self, value=None, children=None):
        self.value = value
        self.children = children if children is not None else []


def minimax(node, depth, alpha, beta, maximizing_player):
    if depth == 0 or not node.children:
        return node.value

    if maximizing_player:
        max_eval = -math.inf
        for child in node.children:
            eval = minimax(child, depth - 1, alpha, beta, False)
            max_eval = max(max_eval, eval)
            alpha = max(alpha, eval)
            if beta <= alpha:
                break
        return max_eval
    else:
        min_eval = math.inf
        for child in node.children:
            eval = minimax(child, depth - 1, alpha, beta, True)
            min_eval = min(min_eval, eval)
            beta = min(beta, eval)
            if beta <= alpha:
                break
        return min_eval


# tree structure
root = Node(children=[
    Node(children=(Node(3),Node(12),Node(8))),
    Node(children=(Node(2),Node(4),Node(6))),
    Node(children=(Node(14),Node(5),Node(2)))
])

best_value = minimax(root, depth=3, alpha=-math.inf, beta=math.inf, maximizing_player=True)
print("Best Value:", best_value)