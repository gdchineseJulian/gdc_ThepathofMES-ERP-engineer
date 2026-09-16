# BASIC SELECT

## 9/17

### 題目: Query a list of CITY names from STATION for cities that have an even ID number.

#### Question!
* **如何判斷偶數**：題目要「偶數 ID (even ID number)」，讓我覺得在SQL也能檢查偶數嗎？也能用表達式嗎？答案是可以，不過我寫 id / 2 = 0 錯了..
* * **重複欄位的處理**：若有同名的城市需要去重（使用 `DISTINCT`）？

#### 💻 SQL CODE
```sql
SELECT DISTINCT CITY
FROM STATION
WHERE MOD(ID,2) = 0;
```


#### 💡 新學到的用法
* **取餘數運算子 (`%` 或 `MOD`)**：
  * 用法：`A % B` 或 `MOD(A, B)` 可以算出 A 除以 B 的餘數。 若要奇數就用 <> 0 偶數則用 = 0
  * 應用：判斷偶數用 `ID % 2 = 0`；若要判斷奇數則用 `ID % 2 <> 0` 或 `ID % 2 = 1`。
* **`DISTINCT`**：在**欄位前面**加上 `DISTINCT` 可以過濾掉重複的資料，像SET()。
