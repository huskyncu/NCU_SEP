# Lab 4.1
# test_calculateDiscounts.py
from calculateDiscounts import calculate_discounts
import pytest

def test_calculate_discounts():
    with pytest.raises(Exception) as error:
        a=[]
        b=[]
        result = calculate_discounts(a,b)
    assert str(error.value) == "Prices and membership levels must be provided as non-empty lists."
    
    with pytest.raises(Exception) as error:
        a=[10,20]
        b=['Gold']
        result = calculate_discounts(a,b)
    assert str(error.value) == "Prices and membership levels lists must have the same length."
    prices = [120, 80, 70, 30, 50,10]
    membership_levels = ['Gold', 'Gold', 'Silver', 'Silver', 'Bronze','Silver']
    expected_discounted_prices = ['96.00', '72.00', '59.50', '28.50', '50.00','9.50']

    result = calculate_discounts(prices, membership_levels)

    assert result == expected_discounted_prices
