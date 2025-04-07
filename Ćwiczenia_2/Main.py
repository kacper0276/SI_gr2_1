from collections import deque

class VacuumCleaner:
    def __init__(self):
        self.actions = ['Left', 'Right', 'Suck']

    def bfs(self, initial_state):
        queue = deque([(initial_state, [])])
        visited = set()

        while queue:
            (state, path) = queue.popleft()

            if self.goal_test(state):
                return path

            visited.add(state)

            for action in self.actions:
                new_state = self.result(state, action)
                if new_state not in visited:
                    queue.append((new_state, path + [action]))

        return []

    def goal_test(self, state):
        location, left_status, right_status = state
        return left_status == 'clean' and right_status == 'clean'

    def result(self, state, action):
        location, left_status, right_status = state

        if action == 'Left' and location == 'B':
            return ('A', left_status, right_status)
        elif action == 'Right' and location == 'A':
            return ('B', left_status, right_status)
        elif action == 'Suck':
            if location == 'A':
                return (location, 'clean', right_status)
            elif location == 'B':
                return (location, left_status, 'clean')

        return state

# Initial state = (A, dirty, dirty)
# Action(initial state) = {suck, right}
# Result(initial state, suck) = (A, clean, dirty)
# Goal state = ([A or B], clean, clean)


initial_states = [
    ('A', 'dirty', 'dirty'),
    ('A', 'clean', 'dirty'),
    ('A', 'dirty', 'clean'),
    ('B', 'dirty', 'dirty'),
    ('B', 'clean', 'dirty'),
    ('B', 'dirty', 'clean'),
    ('A', 'clean', 'clean'),
    ('B', 'clean', 'clean')
]

for initial_state in initial_states:
    vacuum = VacuumCleaner()
    solution = vacuum.bfs(initial_state)
    print(f"Initial state {initial_state}: Sequence of actions to clean the rooms: {solution}")