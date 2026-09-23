# BasicSkill

## 9/23

### 題目: Write a query identifying the type of each record in the TRIANGLES table using its three side lengths. Output one of the following statements for each record in the table: 判斷三角形
 
Equilateral: It's a triangle with  sides of equal length. 三條邊長皆相等。  
Isosceles: It's a triangle with  sides of equal length. 有兩條邊長相等。
Scalene: It's a triangle with  sides of differing lengths. 三條邊長皆不相同。
Not A Triangle: The given values of A, B, and C don't form a triangle. 給定的 A、B、C 長度無法組成三角形（任兩邊之和大於第三邊的條件不成立  


#### My Question!
* **怎麼用CASE WHEN**：
```sql

可以在 WHEN 後面放條件（包含 <, >, =, AND, OR 等）。
CASE 
    WHEN 條件1 THEN 結果1
    WHEN 條件2 THEN 結果2
    WHEN 條件3 THEN 結果3
    ELSE 預設結果
END --SQL 會從第一個 WHEN 開始由上往下檢查。只要遇到第一個成立的條件，就會回傳對應的結果，並直接跳出判斷，後面的條件就不會再執行。如果所有條件都不成立，就會回傳 ELSE 後面的結果（如果沒寫 ELSE 則回傳 NULL）。


SELECT 
    name,
    score,
    CASE 
        WHEN score >= 90 THEN 'A'
        WHEN score >= 80 THEN 'B'
        WHEN score >= 70 THEN 'C'
        WHEN score >= 60 THEN 'D'
        ELSE 'F'
    END AS grade
FROM students;


```

* **為啥CASE WHEN條件順序重要?**：因為 CASE WHEN 就像程式語言裡的 if ... else if ... else，只要符合第一個條件就會立刻跳出，不再執行後面的判斷。用 CASE WHEN 判斷時，邏輯順序非常重要：必須優先排除「無法組成三角形」的情況，接著判斷三邊全相等的正三角形，再判斷兩邊相等的等腰三角形，最後才是不等邊三角形。


#### 💻 SQL
```sql
SELECT 
    CASE 
        
        WHEN A + B <= C OR A + C <= B OR B + C <= A THEN 'Not A Triangle'
       
        WHEN A = B AND B = C THEN 'Equilateral'
        
        WHEN A = B OR B = C OR A = C THEN 'Isosceles'
        
        ELSE 'Scalene'
    END AS Triangle_Type
FROM TRIANGLES;

```

#### 💡 密技  
* **-**



