from data_processor import process_and_store_data
from unittest import mock

@mock.patch('data_processor.Database')
def test_process_and_store_data(MockDataBase):
    mock_db_instance = MockDataBase.return_value
    mock_db_instance.get_all_data.return_value = [1,2,3]
    
    assert process_and_store_data(7)==6