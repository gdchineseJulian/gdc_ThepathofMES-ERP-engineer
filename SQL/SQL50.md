# SQL 50 講義

SQL50的錯題與延伸題目紀錄

---
## 筆記

### 第二題:查詢成績表中的最低分、平均分、總分
- **觀念**：聚合函數
- **答案**：
  ```sql
  SELECT  MIN(score) AS 最低分
          AVG(score) AS 平均分
          SUM(score) AS 總分
  FROM sc;
  ```
  - **重點觀念**：
  - 記得所有聚合函數的方法
  - `WHERE` 字串條件要用單引號 `' '` 包起來。
- 延伸1:查詢成績 60 分以上（包含 60） 的學生共有幾筆成績紀錄。
  ```sql
  SELECT COUNT(score)
  FROM sc
  WHERE score >= 60;
  ```
- **今日心得/解題**：
資料怎麼被處理，再想 SELECT 最後要顯示什麼? 或著 從哪裡拿資料，要把那些資料留下，要顯示什麼？

FROM 哪裡拿資料
↓
WHERE 要不要篩
↓
GROUP BY 要不要分組
↓
HAVING 分組後要不要再篩
↓
最後 SELECT 我要看到哪些東西


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
