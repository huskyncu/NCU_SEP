def find_numbers(numbers):
    if not isinstance(numbers, list):
        raise ValueError("Input should be a list of numbers")

    result = []
    for num in numbers:
        if not isinstance(num, (int, float)):
            raise ValueError("Each item in the list should be a number")

        if num > 0:
            result.append("positive")
        elif num < 0:
            result.append("negative")
        else:
            result.append("zero")
    return result
