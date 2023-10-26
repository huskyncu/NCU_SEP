# test_complex_calculator.py
import pytest
from unittest.mock import Mock,call
from complex_calculator import Calculator


def test_complex_calculation(mocker):
     
    # Test the complex_calculation method
    calculator = Calculator()
    add_spy = mocker.spy(calculator,'add')
    result = calculator.complex_calculation([1, 2, 3, 4])

    # Assert that the add method was called multiple times with the correct arguments
    add_spy.assert_has_calls([call(0, 1), call(1, 2), call(3, 3), call(6, 4)])

    # Assert the result of the complex_calculation method
    assert result == 10

if __name__ == "__main__":
    pytest.main()
