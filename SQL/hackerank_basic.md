# BASIC SELECT


### 題目: 

#### My Question!
* **.**：

#### 💻 SQL
```sql

```


#### 💡 密技
* **-**

### 題目: 

#### 📝 MY QUESTION!
* **`**

#### 💡 密技
* 














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
* **`DISTINCT` 的觀念**：原本一直以為 `DISTINCT` 只是對「輸出結果」SET()的關鍵字，我以為**只能強制放在所有欄的最前面**（例如：`SELECT DISTINCT 欄位A, 欄位B...`）。
* **函數裡面怎麼跑的**：我不確定為什麼 `DISTINCT` 可以被放到 `COUNT()` 的括號裡面，以及它在裡面到底是怎麼被執行的。
```sql
SELECT COUNT(CITY) - COUNT(DISTINCT CITY) AS difference 
FROM STATION;
```

#### 💡 密技
* **`DISTINCT` 用法（關鍵字 vs 修飾字）**：
  * **當關鍵字（放在最前面）**：`SELECT DISTINCT CITY, COUNTRY`。這是對「撈出來的最終結果集」整行進行去重。
  * **當修飾字（放在聚合函數內）**：`COUNT(DISTINCT CITY)`。這時它只針對該欄位生效。SQL 的運作流程是：**「先在記憶體中剔除重複的城市名稱，接著 `COUNT()` 才去數這個去重後的清單有幾筆」**。
* **聚合函數的四則運算**：SQL 允許我們直接將兩個聚合函數的結果進行四則運算（`COUNT(...) - COUNT(...)`）


## 9/18

### 題目: Query the two cities in STATION with the shortest and longest CITY names, as well as their respective lengths (i.e.: number of characters in the name). If there is more than one smallest or largest city, choose the one that comes first when ordered alphabetically.

#### 📝 MY QUESTION!
* **找出字串最短和最長字的城市名字？怎麼不是用聚合函數**：MAX() / MIN() 是找「值」用的，它可以找出最長幾個字，但不知道是什麼字，也就是他不知道是誰。他只能知道最長長度是3，可不知道3的是哪個城市？所以直接用「最小值對應的那筆資料是誰」→ ORDER BY + LIMIT
* **取長度的函數**：LENGTH(欄位)，它是算bytes長度，因此以後碰到中文、越南文等 Unicode 字串，用CHAR_LENGTH()
* **有辦法用一個SELECT就取得所有想要的結果嗎？**：可以，但不要為了「只用外面一個 SELECT」，反而搞得更複雜。SQL 的思維要用最合理的方法取得我要的資料。
* **ORDER BY的排序規則？**：數字 ORDER BY → 按大小 ；日期 ORDER BY → 按時間先後；字串 ORDER BY → 按字典順序（實務上是按collation（排序規則）去排序...不同資料庫有不同規則）
* **為啥不是ORDER BY CITY?**：如果這樣，則SQL會按照字典去排，ex.A、ABBBB，這樣順序跟題目要求不一樣。所以用ORDER BY LENGTH(CITY),CITY，先按長度排，若長度一樣，在按照字典順序排。


#### SQL
```sql
SELECT CITY, LENGTH(CITY)
FROM STATION
ORDER BY LENGTH(CITY), CITY
LIMIT 1;

SELECT CITY, LENGTH(CITY)
FROM STATION
ORDER BY LENGTH(CITY) DESC, CITY
LIMIT 1;
```

#### 💡 密技
* **值和欄位資料的差別**：聚合函數負責取值，它知道特定的值而已，但不知道該值的長相。
* **ORDER BY LENGTH(CITY), CITY**：先按名字長度排序；如果長度相同，再按字典順序排序。




### 題目: Query the list of CITY names starting with vowels (i.e., a, e, i, o, or u) from STATION. Your result cannot contain duplicates.

#### My Question!
* **開頭是母音...，應該沒有這種規則的函數呀，我們能自訂規則嗎？**：用LIKE，搭配萬用字元%%%，用固定的萬用字元去描述想找的字串格式，% = 任意長度的任意字元，0 個也可以；_ = 剛好 1 個任意字元。WHERE CITY = 'Apple'，代表CITY一定是Apple，而WHERE CITY LIKE 'App%'，代表只要App開頭的字都要。
* **我可以用IN搭配LIKE嗎？**：不行，沒有這種語法，IN是不同的比較方式，IN 是把很多個 = 合起來。比如CITY IN ('Apple', 'Osaka', 'Ulm')。

#### 💻 SQL
```sql
SELECT DISTINCT CITY
FROM STATION 
WHERE CITY LIKE 'A%' OR CITY LIKE 'E%' OR CITY LIKE 'I%' OR CITY LIKE 'O%' OR CITY LIKE 'U%';  
```


#### 💡 密技
* **萬用字元**：萬用字元可隨便放，自己搭配。
* **LIKE用法**：LIKKE不等於 = ，所以不用打等於。



