# complex_calculator.py

class Calculator:
    def add(self, a, b):
        return a + b

    def calculate_and_add(self, a, b, c):
        result = a * b
        return self.add(result, c)

    def complex_calculation(self, values):
        # A complex loop calling the add method multiple times
        result = 0
        for val in values:
            result = self.add(result, val)
        return result
