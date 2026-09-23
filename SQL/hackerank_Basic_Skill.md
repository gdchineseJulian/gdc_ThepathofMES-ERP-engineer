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




### 題目: We define an employee's total earnings to be their monthly "salary months" worked, and the maximum total earnings to be the maximum total earnings for any employee in the Employee table. Write a query to find the maximum total earnings for all employees as well as the total number of employees who have maximum total earnings. Then print these values as  space-separated integers.算出「最高總收入」是前提，結果是要How many people得到這最高總收入。每個員工的總收入算式是：月薪 (salary) × 工作月數 (months)。要算出全公司所有人當中，這個乘積的最大值。因為可能不只一位員工賺到這個最高金額，所以要統計達到這個最高收入的總人數。

#### My Question!
* **我算得出來最大值，但怎麼用最大值去回推有幾個人呢..**：先把全公司每個人的總收入都算出來（每個人數字不同沒關係）、找出這個數字的最大值、看這個最大值出現了幾次。

#### 💻 SQL
```sql
SELECT  -- 先算出每個人的總收入，接著把相同收入的人歸為一組並統計人數，最後只取金額最高的那一組
    (salary * months) AS max_earnings,  --計算員工的總收入
    COUNT(*) --搭配 GROUP BY 使用，用來統計每一個組別裡面共有多少筆資料（多少位員工），如果總收入 100,000 的組別裡面有 2 個人，COUNT(*) 的結果就是 2。
FROM Employee
GROUP BY max_earnings --根據算出來的總收入金額進行分組（Grouping）。總收入相同的員工會被合併成同一組。例如，如果小美和小強的總收入都是 100,000，他們就會被歸在 100,000 這個組別中。
ORDER BY max_earnings DESC -- 將分組後的結果，依照總收入金額由大到小（DESC 遞減）進行排序。此時，最高的總收入金額與對應的人數會被排在第一列。
LIMIT 1;
```

#### 💡 密技
* **算式可以直接拿來分組與排序**：GROUP BY 或 ORDER BY 不只能放資料庫原本就有的欄位，還能在查詢時現場計算（salary * months），並直接用這個計算結果來分組和排序。
* **想找除了最大值以外的資訊時**：想找「最高金額、最大數值」並且「同時知道它的附屬資訊（如人數、名稱）」時，ORDER BY ... DESC LIMIT 1 是比單純用 MAX() 更靈活且極度常見的實務寫法

