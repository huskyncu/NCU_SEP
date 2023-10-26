import pytest
from bubble_sort import bubble_sort

def test_bubble_sort():
    
    arr = []
    assert bubble_sort(arr) == []

    arr = [5]
    assert bubble_sort(arr) == [5]

    arr = [2, 7]
    assert bubble_sort(arr) == [2, 7]

    arr = [7, 2]
    assert bubble_sort(arr) == [2, 7]

    arr = [5, 3, 5, 2, 5]
    assert bubble_sort(arr) == [2, 3, 5, 5, 5]

    arr = [3, 3, 3, 3, 3]
    assert bubble_sort(arr) == [3, 3, 3, 3, 3]

    arr = [9, 5, 2, 7, 1, 8, 3, 6, 4]
    assert bubble_sort(arr) == [1, 2, 3, 4, 5, 6, 7, 8, 9]

    arr = [9, 8, 7, 6, 5, 4, 3, 2, 1]
    assert bubble_sort(arr) == [1, 2, 3, 4, 5, 6, 7, 8, 9]

    arr= [2,2,2,2,2,2]
    assert bubble_sort(arr) == [2,2,2,2,2,2]
    
    arr= [9,9,9,1,1,1]
    assert bubble_sort(arr) == [1,1,1,9,9,9]
    
    arr= [-25537,-25536,-1,-3,-6,-4]
    assert bubble_sort(arr) == [-25537,-25536,-6,-4,-3,-1]
    
    arr = list(range(10000,0,-1))
    assert bubble_sort(arr)==list(range(1,10001))