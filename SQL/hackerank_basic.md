# BASIC SELECT

## 9/17

### 題目: Query a list of CITY names from STATION for cities that have an even ID number.

#### My Question!
* **如何判斷偶數**：題目要「偶數 ID (even ID number)」，讓我覺得在SQL也能檢查偶數嗎？也能用表達式嗎？答案是可以，不過我寫 id / 2 = 0 錯了..
* * **重複欄位的處理**：若有同名的城市需要去重（使用 `DISTINCT`）？

#### 💻 SQL
```sql
SELECT DISTINCT CITY
FROM STATION
WHERE MOD(ID,2) = 0;
```


#### 💡 密技
* **取餘數運算子 (`%` 或 `MOD`)**：
  * 用法：`A % B` 或 `MOD(A, B)` 可以算出 A 除以 B 的餘數。 若要奇數就用 <> 0 偶數則用 = 0
  * 應用：判斷偶數用 `ID % 2 = 0`；若要判斷奇數則用 `ID % 2 <> 0` 或 `ID % 2 = 1`。
* **`DISTINCT`**：在**欄位前面**加上 `DISTINCT` 可以過濾掉重複的資料，像SET()。

### 題目: Find the difference between the total number of CITY entries in the table and the number of distinct CITY entries in the table.

#### 📝 MY QUESTION!
* **`DISTINCT` 的觀念**：原本一直以為 `DISTINCT` 是一個針對「最終輸出結果」去重的關鍵字，**只能強制放在所有欄的最前面**（例如：`SELECT DISTINCT 欄位A, 欄位B...`）。
* **函數內部的運作質疑**：我不確定為什麼 `DISTINCT` 可以被放到 `COUNT()` 的括號裡面，以及它在裡面到底是怎麼被執行的。

#### SQL
```sql
SELECT COUNT(CITY) - COUNT(DISTINCT CITY) AS difference 
FROM STATION;
```

#### 💡 密技
* **`DISTINCT` 用法（關鍵字 vs 修飾字）**：
  * **當關鍵字（放在最前面）**：`SELECT DISTINCT CITY, COUNTRY`。這是對「撈出來的最終結果集」整行進行去重。
  * **當修飾字（放在聚合函數內）**：`COUNT(DISTINCT CITY)`。這時它只針對該欄位生效。SQL 的運作流程是：**「先在記憶體中剔除重複的城市名稱，接著 `COUNT()` 才去數這個去重後的清單有幾筆」**。
* **聚合函數的四則運算**：SQL 允許我們直接將兩個聚合函數的結果進行四則運算（`COUNT(...) - COUNT(...)`）




### 題目: Query the two cities in STATION with the shortest and longest CITY names, as well as their respective lengths (i.e.: number of characters in the name). If there is more than one smallest or largest city, choose the one that comes first when ordered alphabetically.

#### 📝 MY QUESTION!
* **`DISTINCT` 的觀念**：

#### SQL
```sql
SELECT COUNT(CITY) - COUNT(DISTINCT CITY) AS difference 
FROM STATION;
```

#### 💡 密技
* **`DISTINCT` 用法（關鍵字 vs 修飾字）**：
  * **當關鍵字（放在最前面）**：`SELECT DISTINCT CITY, COUNTRY`。這是對「撈出來的最終結果集」整行進行去重。
  * **當修飾字（放在聚合函數內）**：`COUNT(DISTINCT CITY)`。這時它只針對該欄位生效。SQL 的運作流程是：**「先在記憶體中剔除重複的城市名稱，接著 `COUNT()` 才去數這個去重後的清單有幾筆」**。
* **聚合函數的四則運算**：SQL 允許我們直接將兩個聚合函數的結果進行四則運算（`COUNT(...) - COUNT(...)`）
