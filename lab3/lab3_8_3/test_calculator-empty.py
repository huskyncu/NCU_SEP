# test_calculator.py
import pytest
from unittest.mock import Mock
from calculator import Calc

def test_calculate_and_add(mocker):
    
    myCalc = Calc()
    # Create a spy object for the add function
    # .............
    spy=mocker.spy(myCalc,'add')
    # Test the calculate_and_add function with input 2,3,4
    # .............
    result = myCalc.calculate_and_add(2,3,4)
    # Assert that the add function was called with the correct arguments
    # ..............
    spy.assert_called_once_with(6,4)
    # Assert the result of the calculate_and_add function， result 
    assert result == 10

if __name__ == "__main__":
    pytest.main()