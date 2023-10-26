import pytest
from unittest import mock
from data_processor import get_and_process_data

@mock.patch('data_processor.fetch_data_from_api', return_value=[1,2,3],autospec=True)
def test_get_and_process_data_returns_list(mock_fetch_data_from_api):
    result = get_and_process_data("https://example.com/api/data")
    assert result == 6
@mock.patch('data_processor.fetch_data_from_api', return_value=None,autospec=True)
def test_get_and_process_data_returns_none(mock_fetch_data_from_api):
    result = get_and_process_data("https://example.com/api/data")
    assert result is None
