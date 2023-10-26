# Lab 4.1
# calculateDiscounts.py

def calculate_discounts(prices, membership_levels):
    if not isinstance(prices, list) or not isinstance(membership_levels, list) or len(prices) == 0 or len(membership_levels) == 0:
        raise ValueError('Prices and membership levels must be provided as non-empty lists.')

    if len(prices) != len(membership_levels):
        raise ValueError('Prices and membership levels lists must have the same length.')

    discounted_prices = []

    for i in range(len(prices)):
        price = prices[i]
        membership_level = membership_levels[i]

        discount = 0

        if membership_level == 'Gold':
            if price >= 100:
                discount = 0.2  # 20% discount
            else:
                discount = 0.1  # 10% discount
        elif membership_level == 'Silver':
            if 50 <= price < 100:
                discount = 0.15  # 15% discount
            else:
                discount = 0.05  # 5% discount

        discounted_price = price - (price * discount)
        if discounted_price >= 10:
            templevel = 'Iron'

        discounted_prices.append(format(discounted_price, '.2f'))

    return discounted_prices
