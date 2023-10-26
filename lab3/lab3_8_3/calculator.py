# calculator.py

class Calc:
    def add(self, a, b):
        return a + b

    def calculate_and_add(self, a, b, c):
        result = a * b
        return self.add(result, c)