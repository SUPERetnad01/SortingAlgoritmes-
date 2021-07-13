import copy


def selection_sort(data):
    for i in range(len(data)):
        min_index = i
        for j in range(i + 1, len(data)):
            if data[min_index] > data[j]:
                min_index = j

        # swap data
        data[i], data[min_index] = data[min_index], data[i]

    return data


def merge_sort(data):
    def split(data):
        middle_index = len(data) // 2
        return data[:middle_index], data[middle_index:]

    def merge(data, temp_array, temp_index, result_index):
        while temp_index < len(temp_array):
            data[result_index] = temp_array[temp_index]
            temp_index += 1
            result_index += 1

    if len(data) > 1:
        # split the data
        left, right = split(data)
        # Sorting the first half
        merge_sort(left)
        # Sorting the second half
        merge_sort(right)

        left_index = right_index = result_index = 0

        # Copy data to temp data arrays left[] and right[]
        while left_index < len(left) and right_index < len(right):
            if left[left_index] < right[right_index]:
                data[result_index] = left[left_index]
                left_index += 1
            else:
                data[result_index] = right[right_index]
                right_index += 1
            result_index += 1

        # Checking if any element was left9
        merge(data, left, left_index, result_index)
        merge(data, right, right_index, result_index)

    return data


def bubble_sort(data):
    n = len(data)
    for i in range(n):
        # Last i elements are already in place
        for j in range(0, n - i - 1):
            if data[j] > data[j + 1]:
                data[j], data[j + 1] = data[j + 1], data[j]
    return data


# Code to print the list


if __name__ == '__main__':
    data = [3, 5, 2, 1, 303, 4, 2, 12, 4, 5, 3, 121]
    selection = selection_sort(copy.deepcopy(data))
    merge = merge_sort(copy.deepcopy(data))
    bubble = bubble_sort(copy.deepcopy(data))
    print(f"selection_sort: {selection}")
    print(f"merge_sort: {merge}")
    print(f"bubble_sort {bubble}")
