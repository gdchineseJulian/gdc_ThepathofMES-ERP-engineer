# SQL 50 講義

SQL50的錯題與延伸題目紀錄

---
## 筆記

### 第二題：查詢成績表中的最低分、平均分、總分

- **觀念**：聚合函數（Aggregate Functions）

- **答案**：

```sql
SELECT  MIN(score) AS 最低分,
        AVG(score) AS 平均分,
        SUM(score) AS 總分
FROM sc;
```

- **重點觀念**：

  - 聚合函數的核心：
    > **把很多筆資料彙整成一個結果。**

  - 常見聚合函數：

    | 函數 | 功能 |
    |---|---|
    | `COUNT()` | 計算筆數 |
    | `SUM()` | 加總 |
    | `AVG()` | 平均 |
    | `MIN()` | 找最小值 |
    | `MAX()` | 找最大值 |

  - 聚合函數的結果 **不一定都是數字**。

    ```sql
    MAX(score)
    ```

    `score` 是數字，所以回傳數字。

    ```sql
    MAX(CITY)
    ```

    `CITY` 是字串，所以會回傳「字串排序最大」的 CITY。

  - 要注意：

    ```sql
    MAX(CITY)
    ```

    是找：

    > 字串排序最大的 CITY

    **不是找 CITY 名稱最長的城市。**

  - 如果要找「城市名稱的最大長度」：

    ```sql
    MAX(LENGTH(CITY))
    ```

    執行概念：

    ```text
    CITY
    ↓
    LENGTH(CITY)
    ↓
    取得每個 CITY 的長度
    ↓
    MAX()
    ↓
    找最大的長度
    ```

  - 例如：

    ```text
    Rome       → 4
    Tokyo      → 5
    Amsterdam  → 9
    ```

    ```sql
    SELECT MAX(LENGTH(CITY))
    FROM STATION;
    ```

    結果：

    ```text
    9
    ```

    但這只代表：

    > 最長的 CITY 名稱長度是 9。

    並不會自動告訴你是哪個 CITY。

  - 如果題目要找的是「最大／最小的那一整筆資料」，通常可以考慮：

    ```sql
    ORDER BY ... DESC
    LIMIT 1;
    ```

    例如找名稱最長的城市：

    ```sql
    SELECT CITY, LENGTH(CITY)
    FROM STATION
    ORDER BY LENGTH(CITY) DESC
    LIMIT 1;
    ```

---

### 延伸 1：查詢成績 60 分以上（包含 60）的學生共有幾筆成績紀錄

```sql
SELECT COUNT(score)
FROM sc
WHERE score >= 60;
```

- `COUNT(*)`
  - 計算資料列總數。
  - 不管某個欄位是不是 `NULL`。

- `COUNT(score)`
  - 計算 `score` **不是 NULL** 的資料筆數。

例如：

```text
score
-----
80
70
NULL
90
```

```sql
SELECT COUNT(*)
FROM sc;
```

結果：

```text
4
```

但是：

```sql
SELECT COUNT(score)
FROM sc;
```

結果：

```text
3
```

---

### 延伸 2：`DISTINCT` 搭配 `COUNT()`

```sql
COUNT(DISTINCT CITY)
```

意思是：

> 先將 CITY 去除重複，再計算有幾個不同的 CITY。

例如：

```text
Taipei
Taipei
Tokyo
Hanoi
Hanoi
```

```sql
SELECT COUNT(DISTINCT CITY)
FROM STATION;
```

結果：

```text
3
```

要注意：

```sql
SELECT DISTINCT CITY
FROM STATION;
```

代表：

> 查詢 CITY，並將重複的 CITY 去除。

而：

```sql
SELECT COUNT(DISTINCT CITY)
FROM STATION;
```

代表：

> 計算「不重複 CITY」的數量。

---

### 心法

資料怎麼被處理，再想最後 `SELECT` 要顯示什麼。

```text
FROM      從哪裡拿資料
↓
WHERE     哪些資料要留下
↓
GROUP BY  要不要分組
↓
HAVING    分組後要不要再篩
↓
SELECT    最後我要看到什麼
```

也可以簡化成三個問題：

```text
1. 從哪裡拿資料？
2. 哪些資料要留下？
3. 最後我要顯示什麼？
```

例如題目：

> 查詢 60 分以上的成績共有幾筆。

思考：

```text
FROM sc
→ 從 sc 拿資料

WHERE score >= 60
→ 留下 60 分以上的資料

SELECT COUNT(*)
→ 最後計算共有幾筆
```

---

### 密技

#### 1. 看到「幾筆、幾個」先想到 `COUNT()`

```sql
COUNT(*)
COUNT(score)
COUNT(DISTINCT CITY)
```

---

#### 2. 看到「最低、最高、平均、總和」想到聚合函數

```text
最低 → MIN()
最高 → MAX()
平均 → AVG()
總和 → SUM()
數量 → COUNT()
```

---

#### 3. `MAX()` / `MIN()` 比的是括號裡面的東西

```sql
MAX(score)
```

→ 比 `score` 的大小。

```sql
MAX(CITY)
```

→ 比 `CITY` 的字串排序。

```sql
MAX(LENGTH(CITY))
```

→ 比 `CITY` 名稱的長度。

**SQL 不會自己猜測你想比較什麼，`MAX()` / `MIN()` 只會比較你括號裡放進去的內容。**

---

#### 4. 聚合函數 vs 找整筆資料

如果題目只是問：

> 最大分數是多少？

可以使用：

```sql
SELECT MAX(score)
FROM sc;
```

但如果題目問：

> 分數最高的那個學生是誰？

只寫：

```sql
MAX(score)
```

是不夠的，因為它只會得到最大分數，不會自動把對應學生一起帶出來。

這種情況通常可以使用：

```sql
SELECT *
FROM sc
ORDER BY score DESC
LIMIT 1;
```

---

#### 5. `WHERE` 字串條件要使用單引號

正確：

```sql
WHERE name = 'Julian';
```

錯誤：

```sql
WHERE name = Julian;
```

---

### 一句話記住聚合函數

> **聚合函數不是單純「算數字的函數」，而是把很多筆資料彙整成一個結果。**

例如：

```text
COUNT() → 算數量
SUM()   → 算總和
AVG()   → 算平均
MIN()   → 找最小值
MAX()   → 找最大值
```
### 第三題:查詢老師 “諶燕” 所帶的課程設數量
- **觀念**：跨表查詢
- **答案**：
  ```sql
  SELECT COUNT(*)
  FROM course c
  JOIN teacher t
  ON c.tno = t.tno
  WHERE t.tname = '諶燕';
  ```
  - **重點觀念**： 跨表查詢 + 用共同欄位 tno 建立關聯，再做聚合統計。




---
