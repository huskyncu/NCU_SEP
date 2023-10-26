# data_processor.py

from data_access import Database

def process_and_store_data(value):
    db = Database()
    db.insert_data(value)
    all_data = db.get_all_data()
    return sum(all_data)
