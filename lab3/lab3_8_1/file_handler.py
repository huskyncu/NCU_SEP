# file_handler.py

class FileHandler:
    def read_file(self, filename):
        with open(filename, 'r') as file:
            return file.read()

    def write_file(self, filename, content):
        with open(filename, 'w') as file:
            file.write(content)
