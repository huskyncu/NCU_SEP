#!/bin/bash

# 獲取所有semaphore IDs
SEM_IDS=$(ipcs -s | awk '/0x[0-9a-fA-F]+/{print $2}')

# 迭代每一個ID並刪除它
for id in $SEM_IDS; do
    ipcrm -s $id
done

echo "所有的semaphore已被刪除。"
