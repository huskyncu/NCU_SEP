# test_classifyTriangle.py
from classifyTriangle import classify_triangle
import pytest



def test_classify_triangle1():
    # Test for Equilateral triangles
    assert classify_triangle(1, 1, 1) == "Equilateral"
def test_classify_triangle2():
    # Test for Isosceles triangles - considering different permutations for side lengths
    assert classify_triangle(3, 4, 3) == "Isosceles"
def test_classify_triangle3():
    # Test for Isosceles triangles - considering different permutations for side lengths
    assert classify_triangle(3, 3, 4) == "Isosceles"
def test_classify_triangle4():
    # Test for Isosceles triangles - considering different permutations for side lengths
    assert classify_triangle(4, 3, 3) == "Isosceles"
def test_classify_triangle5():
    # Test for Scalene triangles
    assert classify_triangle(4, 5, 3) == "Scalene"
    
