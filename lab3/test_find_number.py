import pytest
from findNumbers import find_numbers

def test_find_numbers_basic():
    assert find_numbers([1, -1, 0]) == ['positive', 'negative', 'zero']

def test_invalid_input():
    with pytest.raises(ValueError):
        find_numbers(123)

def test_non_number_input():
    with pytest.raises(ValueError):
        find_numbers([1, 'a', 3])

def test_find_numbers_basic():
    assert find_numbers([1, -1, 0]) == ['positive', 'negative', 'zero']

def test_invalid_input():
    with pytest.raises(ValueError):
        find_numbers(123)

def test_non_number_input():
    with pytest.raises(ValueError):
        find_numbers([1, 'a', 3])

def test_only_positive_numbers():
    assert find_numbers([1, 2, 3, 4]) == ['positive', 'positive', 'positive', 'positive']

def test_only_negative_numbers():
    assert find_numbers([-1, -2, -3, -4]) == ['negative', 'negative', 'negative', 'negative']

def test_only_zeros():
    assert find_numbers([0, 0, 0, 0]) == ['zero', 'zero', 'zero', 'zero']

def test_float_numbers():
    assert find_numbers([1.5, -2.5, 0, 3.5]) == ['positive', 'negative', 'zero', 'positive']

def test_empty_list():
    assert find_numbers([]) == []

def test_large_list():
    large_list = [1, -1, 0] * 1000
    expected_output = ['positive', 'negative', 'zero'] * 1000
    assert find_numbers(large_list) == expected_output
